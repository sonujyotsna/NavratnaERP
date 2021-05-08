
$(document).ready(function () {
    getMainRegistrationList();
   
});

var saveRegistration = function () {
    var message = "";
    $formData = new FormData();
    var photo = document.getElementById('File1');;
    if (photo.files.length > 0) {
        for (var i = 0; i < photo.files.length; i++) {
            $formData.append('file-' + i, photo.files[i]);
            // console.log(image.files[i]);
        }
    }

    var fullname = $("#txtFullName").val();
    $formData.append('FullName', fullname);
    var presentaddress = $("#txtPresentAddress").val();
    $formData.append('PresentAddress', presentaddress);
    var permanentaddress = $("#txtPermanentAddress").val();
    $formData.append('PermanentAddress', permanentaddress);
    var mobno = $("#txtMobNo").val();
    $formData.append('MobNo', mobno);
    var alternetmobno = $("#txtAlternetMobNo").val();
    $formData.append('AlternetMobNo', alternetmobno);
    var adhardetail = $("#txtAdharDetail").val();
    $formData.append('AdharDetail', adhardetail);
    var companyname = $("#ddlCompanyName").val();
    $formData.append('CompanyName', companyname);
    var post = $("#ddlPost").val();
    $formData.append('Post', post);
    var dateofjoining = $("#txtDateofJoining").val();
    $formData.append('DateofJoining', dateofjoining);
    var dateofleaving = $("#txtDateofLeaving").val();
    $formData.append('DateofLeaving', dateofleaving);

    if (fullname == "") {
        message += "Please enter name";
    }
    else if (presentaddress == "") {
        message += "Please enter your present address";
    }
    else if (permanentaddress == "") {
        message += "Please enter Your permanent address";
    }
    else if (mobno == "") {
        message += "Please enter your Mobile No.";
    }
    else if (alternetmobno == "") {
        message += "Please enter  Alternet Mobile no.";
    }
    else if (adhardetail == "") {
        message += "Please enter Adhar Detail";
    }
    else if (companyname == "") {
        message += "Please select Company Name";
    }
    else if (post == "") {
        message += "Please Select Post";
    }
    else if (dateofjoining == "") {
        message += "Please select Date of Joining";
    }
    else if (dateofleaving == "") {
        message += "Please select Date of Birth";

    }
    else if (photo == "") {
        message += "Please select Photo";

    }

    if (message == "") {
        $.ajax({
            url: "/Employee/SaveRegistration",
            type: 'post',
            data: $formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {
                $.alert({
                    title: 'Alert!',
                    content: "Employee Added Successfully..!",
                    type: 'blue'
                });
            }
        });
    }
    else {
        alert(message);
    }
}


var getMainRegistrationList = function () {
    var companyname = $("#ddlCompanyName").val();
    var model = { CompanyName: companyname };

    $.ajax({
        url: "/Employee/GetRegistrationList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblEmployee tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.EmpId + "</td><td>" + elementValue.FullName + "</td><td>" + elementValue.PresentAddress + "</td><td>" + elementValue.PermanentAddress + "</td><td>" + elementValue.MobNo + "</td><td>" + elementValue.AlternetMobNo + "</td><td>" + elementValue.AdharDetail + "</td><td>" + elementValue.CompanyName + "</td><td>" + elementValue.Post + "</td><td>" + elementValue.DateofJoiningString + "</td><td>" + elementValue.DateofLeavingString + "</td><td><img width='100' height='100' src='../Content/images/" + elementValue.Photo + "'/></td><td><input type='submit' value='Family Details' onClick='familyRegistration(" + elementValue.EmpId + ")'/><input type='submit' value='Edit' onClick='editRegistration(" + elementValue.EmpId + ")'/> <input type='submit' value='Delete' onClick='deleteRegistration(" + elementValue.EmpId +")'/></td></tr>";
            });
            $("#tblEmployee ").append(html);

        }
    });
}
var familyRegistration = function (empid) {
    window.location.href = "/EmployeeDetail/Index?EmpId=" + empid;
}
var editRegistration = function (empid) {
    window.location.href = "/Employee/Edit?EmpId=" + empid;
}
var deleteRegistration = function (id) {
    var model = { EmpId: id };
    $.confirm({
        title: 'Alert!',
        content: 'Are you sure you want to delete the Menu?',
        type: 'red',
        buttons: {
            confirm: function () {
                $.ajax({
                    url: "/Employee/deleteRegistration",
                    method: "post",
                    data: JSON.stringify(model),
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        getMainRegistrationList();
                        alert("record Deleted Successfully...");
                    }
                });
            },
            cancel: function () {
                $("#divLoader").hide();
            }
        }
    });
}
