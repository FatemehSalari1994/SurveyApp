$(document).ready(function () {
    $('.send-data').on('click', function (e) {
        e.preventDefault();

        var url = window.location.pathname;
        var id = url.substring(url.lastIndexOf('/') + 1);
        var formData = new FormData();
        formData.append("id", id);

   
        $(".list-group").each(function (x, y) {

            $(y).find(".form-control").each(function (n, m) {
                formData.append($(m).attr("name").replace("[]", "[" + x + "]"), $(m).val());
            });


        });

        $.ajax({
            url: "/Survey/ResponseSurvey",
            data: formData,
            type: "Post",
            async: false,
            cache: false,
            contentType: false,
            enctype: 'multipart/form-data',
            processData: false,
            success: function (data) {
                window.location.href = "/Survey/ShowOpenSurveys";
            }
        });
    });
});
