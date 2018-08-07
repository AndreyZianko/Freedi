 $(function () {
        $("#CreateForm").submit(function (event) {
            var dataString;
            debugger;
            event.preventDefault();

            var action = $("#CreateForm").attr("action");
            if ($("#CreateForm").attr("enctype") == "multipart/form-data") {
                dataString = new FormData($("#CreateForm").get(0));
                contentType = false;
                processData = false;
            } else {
                // regular form, do your own thing if you need it
            }
            $.ajax({
                type: "POST",
                url: action,
                data: dataString,
                dataType: "json", //change to your own, else read my note above on enabling the JsonValueProviderFactory in MVC
                contentType: contentType,
                processData: processData,
                async: false,
                success: function (data) {
                    var k = data;
                    debugger;
                },
                error: function (jqXHR, textStatus, errorThrown) {

                    alert("fail");
                }
            });
        }); //end .submit()
    });

