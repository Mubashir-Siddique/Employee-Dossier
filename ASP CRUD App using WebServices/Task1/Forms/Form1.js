/// <reference path="Form1.asmx" />

var dataglobal;

$(document).ready(function () {
    $('#saveButton').hide();
    GETDatatable();

    $('#close').on("click", function () {
        $('#myModal').css("display", "none");
    });

    $("#File1").click(function () {
        $(this).val("");
    });
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgUpload').attr('src', e.target.result);

            alert(e.target.result);
        }


        //reader.readAsText(input.files[0]);
        reader.readAsDataURL(input.files[0]); // convert to base64 string        
    }
}

function InsertData() {

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    postAppointmentData();

    var mydata = "{'employeeName':'" + $('#inputName').val() + "','empAddress':'" + $('#inputAddress').val() + "','empEmail':'" + $('#inputEmail').val() + "','empImage':'" + dataglobal + "'}";

    var Name = $('#inputName').val();
    var Address = $('#inputAddress').val();
    var Email = $('#inputEmail').val();


    if (Name == "" || Address == "" || Email == "") {
        FieldsEmptyError(Name, Address, Email);
    }

    else if (ValidateEmail(Email)) {
        $.ajax({
            type: "POST",
            url: "Service.asmx/InsertData",
            data: mydata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccessInsertData,
            cache: false
        });
    }
    else {
        $('.errorMessage3').css("visibility", "visible");
    }
}


function postAppointmentData() {
    var filepath, filerespense;
    ////var formData = new FormData();
    ////formData.append('file', $('#File1')[0].files[0]);

    var file_data = $('#File1').prop('files')[0];
    var form_data = new FormData();
    form_data.append('file', file_data);

    $.ajax({
        type: "post",
        url: "FileHandler.ashx/uploadFileURL",
        contentType: false,
        processData: false,
        data: form_data,
        success: function (data, response) {
            if (response == 'success') {

                var appData = data;
                //var appData = JSON.stringify({ filePath: data });
                dataglobal = appData;
            } else {
                //onError();
            }
        },
        //error: onError,
        async: false
    });
}

function GETDatatable() {
    $('#inputName').val('');
    $('#inputAddress').val('');
    $('#inputEmail').val('');

    $.ajax({
        type: "POST",
        url: "Service.asmx/GetAllData",
        //data: "{'EmployeeId':" + EmployeeId + ",'EmployeeExpenseMonthlyId':'" + MonthlyExpenseId + "','ExpenseMonth':'" + MonthOfExpense + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessFillTable,
        //error: onError,
        cache: false,
        async: false,
        //beforeSend: startingAjax,
        //complete: ajaxCompleted
    });

    $('#tblData').DataTable();
}

function OnSuccessFillTable(responce, data) {

    jsonObj = JSON.parse(responce.d);

    var divTableBody = '';

    for (var i = 0; i < jsonObj.length ; i++) {
        divTableBody += '<tr>'
                       // + '<td>' + '<img id="imgUpload" src="../Images/compact-camera.png" max-width: 100%; max-height: 100%;" />' + '</td>'
                        + '<td>' + jsonObj[i].EmployeeID + '</td>'
                        + '<td>' + jsonObj[i].EmployeeName + '</td>'
                        + '<td>' + jsonObj[i].EmpAddress + '</td>'
                        + '<td>' + jsonObj[i].EmpEmail + '</td>'
                        + '<td > <a href="javascript:EditFunct(' + jsonObj[i].EmployeeID + ' ) ;" > Edit | </a>'
                        + '<a href="javascript:DeleteFunct(' + jsonObj[i].EmployeeID + ' ) ;" style="color:red"> Delete </a> </td>'
                        + '</tr>';
    }
    

    var tblHead = '<table id="tblData"  class="table table-striped table-bordered"  style="width:100% " ><thead> <tr style="border:1px ridge black">'
    //+ '<th > Image </th>'
        + '<th  style="width:15px" > ID </th>'
    + '<th > Employee Name </th>'
    + '<th > Employee Address </th>'
    + '<th > Employee Email </th>'
    + '<th > Operations </th>'
    + '</tr></thead><tbody id="divTableBody">'
    + divTableBody
    + '</tbody></table>';

    $('#tableDiv').empty();
    $('#tableDiv').append(tblHead);

    
}

function EditFunct(EmpId) {
    $('#insertBtn').hide();
    $('#saveButton').show();
    $('#custId').val(EmpId);

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    mydata = "{'employeeId':'" + EmpId + "'}";
    $.ajax({
        type: "POST",
        url: "Service.asmx/GetUserByID",
        data: mydata,

        //data: "{'EmployeeId':" + EmployeeId + ",'EmployeeExpenseMonthlyId':'" + MonthlyExpenseId + "','ExpenseMonth':'" + MonthOfExpense + "'}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessFillFields,
        //error: onError,
        cache: false,
        async: false,
        //beforeSend: startingAjax,
        //complete: ajaxCompleted

    });
}

function DeleteFunct(EmpId) {

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    mydata = "{'employeeId':'" + EmpId + "'}";
    $.ajax({
        type: "POST",
        url: "Service.asmx/DeleteUserbyID",
        data: mydata,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GETDatatable,
        //error: onError,
        cache: false,
        async: false,
        //beforeSend: startingAjax,
        //complete: ajaxCompleted

    });
}


function SaveData() {

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    var EmpId = $('#custId').val();
    var mydata = "{'employeeId':'" + EmpId + "','employeeName':'" + $('#inputName').val() + "','empAddress':'" + $('#inputAddress').val() + "','empEmail':'" + $('#inputEmail').val() + "'}";

    var Name = $('#inputName').val();
    var Address = $('#inputAddress').val();
    var Email = $('#inputEmail').val();

    if (Name == "" || Address == "" || Email == "") {
        FieldsEmptyError(Name, Address, Email);
    }
    else if (ValidateEmail(Email)) {
        $.ajax({
            type: "POST",
            url: "Service.asmx/UpdateData",
            data: mydata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccessInsertData,
            cache: false
        });
    }
    else {
        $('.errorMessage3').css("visibility", "visible");
    }

}


function onSuccessInsertData(responce, data) {

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    if (responce.d != "") {
        jsonObj = JSON.parse(responce.d);
        if (jsonObj[0].Column1 == "DUPLICATE") {
            $('#myModal').show();
        }
    }

    GETDatatable();

    $('#insertBtn').show();
    $('#saveButton').hide();
}

function OnSuccessFillFields(responce, data) {

    $('.errorMessage1').css("visibility", "hidden");
    $('.errorMessage2').css("visibility", "hidden");
    $('.errorMessage3').css("visibility", "hidden");

    jsonObj = JSON.parse(responce.d);
    $('#inputName').val(jsonObj[0].EmployeeName);
    $('#inputAddress').val(jsonObj[0].EmpAddress);
    $('#inputEmail').val(jsonObj[0].EmpEmail);

}


// When the user clicks the button, open the modal 
function FieldsEmptyError(Name, Address, Email) {

    if (Name == "") {
        $('.errorMessage1').css("visibility", "visible");
    }
    if (Address == "") {
        $('.errorMessage2').css("visibility", "visible");
    }
    if (Email == "" || !ValidateEmail(Email)) {
        $('.errorMessage3').css("visibility", "visible");
    }
}

function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    return (false)
}
 