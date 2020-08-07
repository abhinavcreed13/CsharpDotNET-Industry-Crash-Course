function AppDataModel() {
    var self = this;
    // Routes
    self.userInfoUrl = "/api/Me";
    self.siteUrl = "/";

    self.dataApiInfoUrl = "/api/DataApi";

    self.getPhoneDataUrl = "/api/DataApi/GetPhoneData";

    self.addToCartUrl = "/api/DataApi/AddToCart";

    self.removeFromCart = "/api/DataApi/RemoveFromCart";

    // Route operations

    // Other private operations

    // Operations

    // Data
    self.returnUrl = self.siteUrl;

    // Data access operations
    self.setAccessToken = function (accessToken) {
        sessionStorage.setItem("accessToken", accessToken);
    };

    self.getAccessToken = function () {
        return sessionStorage.getItem("accessToken");
    };
}
