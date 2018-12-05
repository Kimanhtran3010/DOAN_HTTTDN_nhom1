var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {

        $('#btn_continue').on('click', function () {
            window.location.href = "#";
        });

        $('#btn_update').on('click', function () {
            var listproduct = $('#txt_number');

            var cartList = [];
            jQuery.each(listproduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        IDRoBot: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: 'gio-hang/update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',

                success: function (res) {
                    console.log(res);
                    window.location.href = "gio-hang";
                }

            })
        });

    }
}
cart.init();