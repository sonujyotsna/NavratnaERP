
$(document).ready(function () {
    editRegistration();

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
    var empid = $("#hdnEmpId").val();
    $formData.append('EmpId', empid);
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
                    content: "Employee Updated Successfully..!",
                    type: 'blue'
                });
            }
        });
    }
    else {
        alert(message);
    }
}

var editRegistration = function () {
    var empid = $("#hdnEmpId").val();
    var model = { EmpId: empid };
   
    $.ajax({
        url: "/Employee/GetEditRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            
            $("#hdnId").val(response.model.EmpId);
            $("#txtFullName").val(response.model.FullName);
            $("#txtPresentAddress").val(response.model.PresentAddress);
            $("#txtPermanentAddress").val(response.model.PermanentAddress);
            $("#txtMobNo").val(response.model.MobNo);
            $("#txtAlternetMobNo").val(response.model.AlternetMobNo);
            $("#txtAdharDetail").val(response.model.AdharDetail);
            $("#ddlCompanyName").val(response.model.CompanyName);
            $("#ddlPost").val(response.model.Post);
            $("#txtDateofJoining").val(response.model.DateofJoiningString)
            $("#txtDateofLeaving").val(response.model.DateofLeavingString)
            $("#File1").val(response.model.Photo);
        }
    });
}