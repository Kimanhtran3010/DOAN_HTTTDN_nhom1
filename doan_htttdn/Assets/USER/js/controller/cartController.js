var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {

        $('#btn_continue').on('click', function () {
            window.location.href = "/USER/trang-chu";
        });

        $('#btn_update').on('click', function () {
            
            var listproduct = $('input#txt_number');           
            var cartList = [];
            $.each(listproduct, function (i, item) {
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

            });
        });
        $('#btn_delete').on('click', function () {
            $.ajax({
                url: 'gio-hang/delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',

                success: function (res) {
                    console.log(res);
                    window.location.href = "gio-hang";
                }

            });
        });
    }
};
cart.init();