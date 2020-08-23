var member;
var present=0;


$.ajax({
    url: '/api/AspNetUsers',
    type: 'GET',
    data: '',
    async: true,
    success: function (response) {
        var email = localStorage.getItem('Email');
        console.log(email);
        member = response.find(x => x.userName == email);

        present = member.present;


        document.getElementById('present').innerHTML = present;

    }
})


