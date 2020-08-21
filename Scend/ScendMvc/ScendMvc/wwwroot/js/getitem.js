
var member;


$.ajax({
    url:'/api/AspNetUsers',
    type: 'GET',
    data: '',
    async: true,
    success: function (response) {
        var email = localStorage.getItem('Email');
        console.log(email);
        member = response.find(x => x.userName == email);
        test._data.present = member.present;

        
       
        
    }
})



