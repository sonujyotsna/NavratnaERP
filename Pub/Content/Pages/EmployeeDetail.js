$(document).ready(function () {
    getRegistrationList();
});

var saveRegistration = function () {
    var empid = $("#txtEmpId").val();
    var familymembername = $("#txtFamilyMemberName").val();
    var memberrelation = $("#ddlMemberRelation").val();
    var presentaddress = $("#txtPresentAddress").val();
    var mobno = $("#txtMobNo").val();
    var alternetmobileno = $("#txtAlternetMobNo").val();
    var adhardetail = $("#txtAdharDetail").val();
    var occupation = $("#txtOccupation").val();
    var companyname = $("#txtCompanyName").val();
    
    var model = { EmpId : empid,FamilyMemberName: familymembername, MemberRelation : memberrelation,PresentAddress : presentaddress,  MobNo: mobno, AlternetMobNo: alternetmobileno, AdharDetail: adhardetail, Occupation : occupation,CompanyName: companyname };
    $.ajax({
        url: "/EmployeeDetail/SaveRegistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.alert({
                title: 'Alert!',
                content: "Family Details Added Successfully..!",
                type: 'blue'
            });
            getRegistrationList();
        }

    });
}

var getRegistrationList = function () {
    var empid = $("#txtEmpId").val();
    var model = { EmpId: empid };

    $.ajax({
        url: "/EmployeeDetail/GetRegistrationList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblEmployeeDetail tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.EmpDetailsId + "</td><td>" + elementValue.EmpId + "</td><td>" + elementValue.FamilyMemberName + "</td><td>" + elementValue.MemberRelation + "</td><td>" + elementValue.PresentAddress + "</td><td>" + elementValue.MobNo + "</td><td>" + elementValue.AlternetMobNo + "</td><td>" + elementValue.AdharDetail + "</td><td>" + elementValue.Occupation + "</td><td>" +elementValue.CompanyName  + "</td></tr>";
            });
            $("#tblEmployeeDetail ").append(html);

        }
    });
}