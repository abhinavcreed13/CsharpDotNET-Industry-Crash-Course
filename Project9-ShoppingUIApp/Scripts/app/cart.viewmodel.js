function CartViewModel(app, dataModel) {
    var self = this;

    Sammy(function () {
        this.get('#cart', function () {
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
        });
    });
}

app.addViewModel({
    name: "Cart",
    bindingMemberName: "cart",
    factory: CartViewModel
});