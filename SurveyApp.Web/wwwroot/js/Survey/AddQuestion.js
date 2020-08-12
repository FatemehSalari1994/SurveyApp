$(document).ready(function () {
    $("#add-button").click(function () {
        var selectionTitleInput = $(this).closest(".form-group").find(".form-control");
        if (selectionTitleInput.val()!="") {
            $("#SelectionsTable tbody").append("<tr><td class='selction-title'>" + selectionTitleInput.val() + "</td><td><button class='btn btn-danger delete-tr' type='button'>x</button></td></tr>");
            selectionTitleInput.val('');
        }
    });
    $("form").submit(function () {

        var array = new Array();
        $(".selction-title").each(function () {
            array.push($(this).html());
        });
        $("#SelectionsTitles").val(array);
    });
});

$(document).on("click", ".delete-tr", function () {
    $(this).closest("tr").remove();
});