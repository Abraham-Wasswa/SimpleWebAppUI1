var app = new Vue({
    el: '#app',
    data: {
        price: 0
    },

    computed: {
        formatPrice: function () {
            return "$" + this.price;
        }
    }
});

var Drop = new Vue({
    el: '#me',
    data: {
        List: '@Model'
    },
    methords: {
        List: function () {
            onclick(this.List);
        }
    }
});