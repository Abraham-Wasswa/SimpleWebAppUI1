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
        myModel: {},
        myOption: {},
        myOptions: [
            { id: 1, Category: "animal" },
            { id: 2, Category: "career" },
            { id: 3, Category: "celebrity" },
            { id: 4, Category: "dev" },
            { id: 5, Category: "explicit" },
            { id: 6, Category: "fashion" },
            { id: 7, Category: "food" },
            { id: 8, Category: "history" },
            { id: 9, Category: "money" },
            { id: 10, Category: "movie" },
            { id: 11, Category: "music" },
            { id: 12, Category: "political" },
            { id: 13, Category: "religion" },
            { id: 14, Category: "science" },
            { id: 15, Category: "sport" },
            { id: 16, Category: "travel" }
        ]
    }
});