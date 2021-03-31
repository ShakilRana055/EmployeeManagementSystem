

(function () {
    $(".select2").select2();

    let selector = {
        employeeCreatForm: $("#employeeCreatForm"),
        departmentId: $("#DepartmentId"),
        employeeId: $("#EmployeeId"),
        employeeCreateBtn: $("#employeeCreateBtn"),
        photo: $("#Photo"),
        nIDPhoto: $("#NIDPhoto"),
        birthCertificate: $("#BirthCertificate"),

    }

    class Employee {
        SaveData() {
            var formData = new FormData(selector.employeeCreatForm[0]);
            formData.append("Photo", selector.photo.get(0).files);
            formData.append("NIDPhoto", selector.nIDPhoto.get(0).files);
            formData.append("BirthCertificate", selector.birthCertificate.get(0).files);
            let response = ajaxOperation.SaveAjax("/Employee/CreateEmployee", formData);
            tostrMessage.SavedMessage(response);
            response === true ? selector.employeeCreatForm[0].reset() : true;
        }
        EmployeeId(departmentId) {
            let employeeId = ajaxOperation.GetAjaxById("/Employee/EmployeeId", departmentId);
            selector.employeeId.val(employeeId);
        }
    }

    let ajaxOperation = new AjaxOperation();
    let tostrMessage = new TostrMessage();
    let employee = new Employee();

    selector.employeeCreateBtn.click(function () {
        employee.SaveData();
    });

    selector.departmentId.change(function () {
        if ($(this).val() !== "") {
            employee.EmployeeId($(this).val());
        }
    });

})();