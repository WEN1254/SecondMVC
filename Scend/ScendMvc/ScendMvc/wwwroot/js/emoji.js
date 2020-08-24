
var category;
$.ajax({
    url: 'https://emoji-api.com/emojis?access_key=6219f172e6b9b78d96fb8d926869fd53fae941ae',
    type: 'GET',
    data: '',
    async: true,
    success: function (response) {

        category = response;

        CreateCategory(category);
    }
})

function CreateCategory(x) {
    Array.prototype.groupBy = function (prop) {
        return this.reduce(function (groups, item) {
            const val = item[prop]
            groups[val] = groups[val] || []
            groups[val].push(item)
            return groups
        }, {})
    };
    const groupbycharacter = x.groupBy('group');
    console.log(`${groupbycharacter}`)
    for (var x in groupbycharacter) {
        var emojitable = document.getElementById('emojitable');
        var categorybtn = document.createElement('b-tab');
        
        categorybtn.title = `${x}`;
        emojitable.appendChild(categorybtn);
        var emojichil = document.createElement(`div${x}`);;
        groupbycharacter[x].forEach(e => {
           
            const emojibtn = document.createElement('button');
            emojibtn.innerHTML = `${e.character}`;
            emojibtn.setAttribute('onclick', `push(this)`);
            emojichil.appendChild(emojibtn);
           

        });
        emojitable.appendChild(emojichil);
     
    }
   
   

}



function push(x,y) {
    
    document.getElementById('msg').value += x.innerHTML;

}

