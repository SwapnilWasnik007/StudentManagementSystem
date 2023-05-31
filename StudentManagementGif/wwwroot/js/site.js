// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var jsonObj = [];

$(document).ready(function () {
    $('#isActive').change(function () {
        var isChecked = $(this).is(':checked');
        var id = $("#Id").val();
        if (isChecked == true)
            console.log("checked / " + id);
        else
            console.log("unchecked / " + id);
    });
});


function CollectActiveStatus(isChecked, studentId) {
    item = {}
    item["Id"] = studentId;
    item["Active"] = isChecked;
    var existingIndex = jsonObj.findIndex(x => x.Id === studentId);

    if (existingIndex === -1) {
        //Add new entry
        jsonObj.push(item);
    }
    else {
        //update existing entry
        jsonObj[existingIndex].Active = isChecked;
    }
    document.getElementById("btnUpdateStatus").disabled = false;
}


function UpdateActiveStatus() {

    console.log(JSON.stringify(jsonObj));

    $.ajax({
        url: 'student/UpdateActiveStatus',
        data: JSON.stringify(jsonObj),
        type: 'POST',
        traditional: true,
        contentType: 'application/json',
        success: function (data) {
            jsonObj = [];
            document.getElementById("btnUpdateStatus").disabled = true;
            alert("Status updated successfully");
        }
    });

}
