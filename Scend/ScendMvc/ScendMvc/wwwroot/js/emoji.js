
//var category = ['', '😀', '😁', '😡', '🦅', '🐓', '🍌', '🚗', '🍔'];
var category;
$.ajax({
    url:'https://emoji-api.com/emojis?access_key=6219f172e6b9b78d96fb8d926869fd53fae941ae',
    type: 'GET',
    data: '',
    async: true,
    success: function (response) {

        category = response;
        
        CreateCategory(category);
    }
})

function CreateCategory(x) {
    const groupBy = (array, key) => {
        // Return the end result
        return array.reduce((result, currentValue) => {
            // If an array already present for key, push it to the array. Else create an array and push the object
            (result[currentValue[key]] = result[currentValue[key]] || []).push(
                currentValue
            );
            // Return the current iteration `result` value, this will be taken as next iteration `result` value and accumulate
            return result;
        }, {}); // empty object is the initial value for result object
    };
    const groupbycharacter = groupBy(x, 'group');
    groupbycharacter.forEach(x => {
    var emojibtn = document.createElement('option')
    emojibtn.innerHTML = x;

    emoji.appendChild(emojibtn);


});
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