function HomeViewModel(app, dataModel) {
    var self = this;

    self.header = ko.observable("");

    self.phoneData = ko.observable([]);

    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.dataApiInfoUrl,
                contentType: "application/json; charset=utf-8",
                //headers: {
                //    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                //},
                success: function (data) {
                    self.header(data);
                }
            });

            //get all phone data
            $.ajax({
                method: 'get',
                url: app.dataModel.getPhoneDataUrl,
                contentType: "application/json; charset=utf-8",
                //headers: {
                //    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                //},
                success: function (data) {
                    $(data).each(function (item) {
                        this.isAddedInCart = ko.observable(this.isAddedInCart);
                    });
                    self.phoneData(data);
                }
            });
        });
        this.get('/', function () {
            this.app.runRoute('get', '#home');
        });
    });

    self.addToCart = function (record) {
        $.ajax({
            method: 'post',
            url: app.dataModel.addToCartUrl,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(record),
            success: function (data) {
                if (data.added) {
                    record.isAddedInCart(true);
                }
            }
        });
    }

    self.removeFromCart = function (record) {
        $.ajax({
            method: 'post',
            url: app.dataModel.removeFromCart,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(record),
            success: function (data) {
                if (data.removed) {
                    record.isAddedInCart(false);
                }
            }
        });
    }

    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
