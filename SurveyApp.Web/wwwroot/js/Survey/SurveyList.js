$('#myTable').DataTable({
    ajax: {
        url: '/Survey/LoadSurveys',
        data: JSON.stringify(data),
        type: "POST",
        dataType: 'JSON',
        contentType: "application/json",
        success: function (data) {
            //do stuff with json result 
        },
        error: function (passParams) {
            console.log("Error is " + passParams);
        }
    },
    columns: [
        { data: 'Title' }
    ]
});