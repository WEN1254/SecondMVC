


var test = new Vue({
    el: '#block1',
    data: {
        max: 50,
        value: 33,
        viewitem :[],
    },
    created: function () {
        $.ajax({
            url: '/api/Proposals',
            type: 'GET',
            data: '',
            async: true,
            success: function (response) {
                console.log(response[1]);
                test._data.viewitem = response[1];
                test._data.max = response[1].target;
                test._data.max = response[1].currentAmount;
                
            }
        })
    },



});