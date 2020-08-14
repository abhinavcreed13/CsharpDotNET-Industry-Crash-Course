function CartViewModel(app, dataModel) {
    var self = this;

    self.cartItems = ko.observableArray();

    dataModel.showCart = ko.observable(false);

    Sammy(function () {
        this.get('#cart', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.getCartItems,
                contentType: "application/json; charset=utf-8",
                //headers: {
                //    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                //},
                success: function (cartItems) {
                    self.cartItems(cartItems); 
                    dataModel.showHome(false);
                    dataModel.showCart(true);
                }
            });
        });
    });

    self.removeFromCart = function (parent, record) {
        $.ajax({
            method: 'post',
            url: app.dataModel.removeFromCart,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(record),
            success: function (data) {
                if (data.removed) {
                    parent.cartItems.remove(function (cartItem) {
                        return cartItem.deviceNumber == record.deviceNumber
                    });
                }
            }
        });
    }
}

app.addViewModel({
    name: "Cart",
    bindingMemberName: "cart",
    factory: CartViewModel
});