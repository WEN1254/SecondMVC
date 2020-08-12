const defaultOptions = {
    speed: 1,   // 速度
    fontSize: 20,// 字体
    color: 'gold', // 颜色
    opacity: 0.9, // 不透明度a
    data: []
}
class Barrage {
    constructor (obj, ctx) {
        this.value = obj.value; // 弹幕内容
        this.time = obj.time;   // 弹幕时间
        this.obj = obj;
        this.ctx = ctx;
        // 初始化状态位，默认没有初始化
        this.isInited = false;
        // 渲染状态位，默认没有渲染过
        this.flag = false;
    }
    init () {
        // 弹幕属性
        this.opacity = this.obj.opacity || this.ctx.opacity;
        this.color = this.obj.color || this.ctx.color;
        this.fontSize = this.obj.fontSize || this.ctx.fontSize;
        this.speed = this.obj.speed || this.ctx.speed;
        // 初始化完毕
        this.isInited = true;
        // 求自身宽度，确定是否继续绘制
        let span = document.createElement('span')
        span.innerHTML = this.value;
        span.style.font = this.fontSize + 'px "Microsoft YaHei"';
        span.style.position = 'absolute';
        document.body.appendChild(span);
        // 弹幕宽度
        this.width = span.clientWidth;
        document.body.removeChild(span);
        // 弹幕位置
        this.pos_x = this.ctx.canvas.width;
        this.pos_y = this.ctx.canvas.height * Math.random();
        // 保证弹幕在 canvas 内部
        if ( this.pos_y < this.fontSize ) {
            this.pos_y = this.fontSize;
        }
        if ( this.pos_y > this.ctx.canvas.height - this.fontSize ) {
            this.pos_y = this.ctx.canvas.height - this.fontSize
        }
    }
    // 弹幕渲染
    render () {
        this.ctx.context.globalAlpha = this.opacity;
        this.ctx.context.font = this.fontSize + 'px "Microsoft YaHei"';
        this.ctx.context.fillStyle = this.color;
        this.ctx.context.fillText(this.value, this.pos_x, this.pos_y);
    }
}
class CanvasBarrage {
    constructor (canvas, video, options = {}) {
        // 判断
        if ( !canvas || !video ) return;
        this.canvas = canvas;
        this.video = video;
        // 设置 canvas 的宽高
        this.canvas.width = video.clientWidth;
        this.canvas.height = video.clientHeight;
        // 绘图上下文
        this.context = canvas.getContext('2d');
        // 对象合并，挂载到实例上
        Object.assign(this, defaultOptions, options);
        // 默认暂停状态，不渲染弹幕
        this.isPaused = true;
        // 弹幕合集，创造弹幕实例
        this.barrages = this.data.map(obj => new Barrage(obj, this))
        // 渲染弹幕
        this.render()
    }
    // 渲染弹幕
    render () {
        // 清空画布
        this.context.clearRect(0, 0, this.canvas.width, this.canvas.height);
        // 绘制弹幕
        this.renderBarrage();
        // 没有暂停，就继续渲染
        if ( this.isPaused === false ) {
            window.requestAnimationFrame(this.render.bind(this))
        }
    }
    // 绘制弹幕
    renderBarrage () {
        // 视频时间
        const currentTime = this.video.currentTime;
        // 渲染弹幕，必须判断弹幕时间与视频时间是否匹配
        this.barrages.forEach(barrage => {
            if ( !barrage.flag && currentTime >= barrage.time ) {
                // 初始化弹幕
                if ( !barrage.isInited ) {
                    barrage.init();
                }
                // 弹幕移动
                barrage.pos_x -= barrage.speed;
                barrage.render();
                // 停止
                if ( barrage.pos_x <= barrage.width * -1 ) {
                    barrage.flag = true;
                }
            }
        })
    }
    // 添加弹幕
    addBarrage (obj) {
        this.barrages.push(new Barrage(obj, this))
    }
    // 重置
    reset () {
        this.context.clearRect(0, 0, this.canvas.width, this.canvas.height);
        const currentTime = this.video.currentTime;
        this.barrages.forEach(barrage => {
            barrage.flag = false;
            // 重新初始化
            if ( currentTime <= barrage.time ) {
                barrage.isInited = false;
            } else {
                // 其他弹幕不渲染
                barrage.flag = true;
            }
        })
    }
}