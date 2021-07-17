var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtSearchNameProduct").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/ProductUser/ListName",
                    dataType: "json",
                    data: {
                        nameProduct: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtSearchNameProduct").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtSearchNameProduct").val(ui.item.label);

                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };
    }
}

common.init();