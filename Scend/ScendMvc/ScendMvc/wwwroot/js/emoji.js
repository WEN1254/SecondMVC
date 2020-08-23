
//var category = ['', '😀', '😁', '😡', '🦅', '🐓', '🍌', '🚗', '🍔'];
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
    ary = new Array();
    for (x in groupbycharacter) ary[ary.length] = x;
    debugger;

    //groupbycharacter.forEach(x => {
    //var emojibtn = document.createElement('option')
    //emojibtn.innerHTML = x;

    //emoji.appendChild(emojibtn);


    //});
    debugger;
}




//var emoji = document.getElementById('emoji');

//category.forEach(x => {
//    var emojibtn = document.createElement('option')
//    emojibtn.innerHTML = x;

//    emoji.appendChild(emojibtn);


//});
//function push() {
//    const x = document.getElementById('emoji');
//    const num = x.selectedIndex;
//    document.getElementById('msg').value += category[num];

//}

var face={
    "slug": "beaming-face-with-smiling-eyes",
        "character": "\ud83d\ude01",
            "unicodeName": "beaming face with smiling eyes",
                "codePoint": "1F601",
                    "group": "smileys-emotion",
                        "subGroup": "face-smiling"
};
console.log(`${face.slug},${face.character},${face.codePoint}`);