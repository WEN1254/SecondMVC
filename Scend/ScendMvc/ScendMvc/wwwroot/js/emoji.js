
var category = ['😀','😁','😡','🦅','🐓','🍌','🚗','🍔'];

//$.ajax({
//    url:'https://emoji-api.com/categories?access_key=6219f172e6b9b78d96fb8d926869fd53fae941ae',
//    type: 'GET',
//    data: '',
//    async: true,
//    success: function (response) {

//        category = response;
//        debugger;
//        CreateCategory();
//    }
//})

//function CreateCategory() {
//}
var emoji = document.getElementById('emoji');

category.forEach(x => {
    var emojibtn = document.createElement('option')
    emojibtn.innerHTML = x;
   
    emoji.appendChild(emojibtn);


});
function push() {
   const x = document.getElementById('emoji');
    const num = x.selectedIndex-1;
    document.getElementById('msg').value += category[num];
   
}