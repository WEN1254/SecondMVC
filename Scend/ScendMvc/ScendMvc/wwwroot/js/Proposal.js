function openClass(evt, className) {
    var i, x, tablinks;
    // x抓取頁面中的class="class"
    x = document.getElementsByClassName("class");
    //計算x的長度並將這些class="class"都進行display:none隱藏的動作
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    //tablinks 抓取頁面中的tablink
    tablinks = document.getElementsByClassName("tablink");
    //將tablinks代入for循環中並利用classList.remove刪除class="red" ，就是每執行一次function的時候就進行全部tablinks移除class="red"
    for (i = 0; i < x.length; i++) {
        tablinks[i].classList.remove("red");
    }
    //document.getElementById=className(函數帶進來的參數)樣式設定為display:block; 當前點擊的a link執行function 顯示出來對應的內容。
    document.getElementById(className).style.display = "block";
    //並對當前點擊的 a link 新增“red” 這個class
    evt.currentTarget.classList.add("red");
}
//預設testbtn 這個class頁面一加載後執行click();的動作。也就是點擊了testbtn有這個class的按鈕來執行上方寫的function 
var mybtn = document.getElementsByClassName("testbtn")[0];
mybtn.click();


ClassicEditor.create(document.querySelector('#editor')).then(editor => { console.log(editor); })


var Poutline = new Vue({
    el: "#P_outline",
    data() {
        return {
            selected: null,
            file: null,
            image: ''
        }
    },
    methods: {
        formatNames(files) {
            if (files.length === 1) {
                return files[0].name
            } else {
                return `${files.length} files selected`
            }
        },
        fileSelected(event) {
            const file = event.target.files.item(0); //取得File物件
            const reader = new FileReader(); //建立FileReader 監聽 Load 事件
            reader.addEventListener('load', this.imageLoader);
            reader.readAsDataURL(file);
        },
        imageLoader(event) {
            this.image = event.target.result;
        }
    },

});


var Setting = new Vue({
    el: '#Setting',
    data: {},
    data() {
        return {
            text: '',
            value: '',
            selected: null,
            options: [{
                value: null,
                text: 'Please select an option'
            },
            {
                value: 'a',
                text: 'This is First option'
            },
            {
                value: 'b',
                text: 'Selected Option'
            },
            {
                value: {
                    C: '3PO'
                },
                text: 'This is an option with object value'
            },
                // { value: 'd', text: 'This one is disabled', disabled: true }
            ],
            number: '',
            date: '',
            image: ''
        }
    },
    methods: {
        formatNames(files) {
            if (files.length === 1) {
                return files[0].name
            } else {
                return `${files.length} files selected`
            }
        },
        fileSelected(event) {
            const file = event.target.files.item(0); //取得File物件
            const reader = new FileReader(); //建立FileReader 監聽 Load 事件
            reader.addEventListener('load', this.imageLoader);
            reader.readAsDataURL(file);
        },
        imageLoader(event) {
            this.image = event.target.result;
        }
    },
})


var Pinformation = new Vue({
    el: '#P_information',
    data: {},
    data() {
        return {
            selected_identity: null,
            Name: '',
            email: '',
            Tel: '',
            identity: '',
            ShowName: '',
            introduction: '',
            Fanpage: '',
            Projectwebsite: '',
            options_identity: [{
                value: null,
                text: '個人'
            },
            {
                value: 'a',
                text: '公司'
            },
            {
                value: 'b',
                text: '非營利'
            },
            ],
            image_team: '',

        }
    },
    methods: {
        formatNames(files) {
            if (files.length === 1) {
                return files[0].name
            } else {
                return `${files.length} files selected`
            }
        },
        fileSelected_image_team(event) {
            const file = event.target.files.item(0); //取得File物件
            const reader = new FileReader(); //建立FileReader 監聽 Load 事件
            reader.addEventListener('load', this.imageLoader_image_team);
            reader.readAsDataURL(file);
        },

        imageLoader_image_team(event) {
            this.image_team = event.target.result;
        },
    }
})