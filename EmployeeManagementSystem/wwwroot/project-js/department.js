

(function () {
    let selector = {
        departmentCreatForm: $("#departmentCreatForm"),
        name: $("#Name"),
        code: $("#Code"),
        description: $("#Description"),
        departmentCreateBtn: $("#departmentCreateBtn"),
        departmentList: $("#departmentList"),
        tableInformation: '',
        Id: '',
        edit: ".editDepartment",
        delete: ".deleteDepartment",
    }

    class Department {
        constructor() { }
        DepartmentList() {
            var departmentList = selector.departmentList.dataTable({
                "processing": true,
                "serverSide": true,
                "filter": true,
                "pageLength": 10,
                "autoWidth": false,
                "lengthMenu": [[10, 50, 100, 500, 1000, 10000], [10, 50, 100, 500, 1000, 10000]],
                "order": [[0, "desc"]],
                "ajax": {
                    "url": "/Department/DepartmentList/",
                    "type": "POST",
                    "data": function (data) {
                    },
                    "complete": function (json) {
                    }
                },
                "columnDefs": [
                    { "className": "textAlign", "targets": [0, 1, 2, 3] },
                ],
                "columns": [
                    { "data": "name", "name": "name", "autowidth": true, "orderable": true },
                    { "data": "code", "name": "code", "autowidth": true, "orderable": true },
                    { "data": "description", "name": "description", "autowidth": true, "orderable": true },

                    {
                        "render": function (data, type, full, meta) {
                            return `
                                <div class="btn-group">
                                    <i class="fa fa-ellipsis-h" title = 'Actions' style = 'cursor:pointer;' data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i>
                                  <div class="dropdown-menu" >
                                    <button style="font-size: inherit;" class="dropdown-item btn-rx editDepartment" name = "${full.name}" code = "${full.code}" description = "${full.description}" departmentId = "${full.id}" ><i class="fa fa-check-circle" aria-hidden="true"></i>Edit</button >
                                    <button style="font-size: inherit;" class="dropdown-item btn-rx deleteDepartment" departmentId = "${full.id}" > <i class="fa fa-times" aria-hidden="true"></i>Delete</button >
                                  </div>
                                </div>`;
                        }
                    },
                ]
            });
            selector.tableInformation = departmentList;
        }
        SaveData() {
            var formData = new FormData(selector.departmentCreatForm[0]);
            let response = ajaxOperation.SaveAjax("/Department/Index", formData);
            tostrMessage.SavedMessage(response);
            response === true ? selector.departmentCreatForm[0].reset() : true;
            selector.tableInformation.fnFilter();
        }
        UpdateData() {
            var formData = new FormData(selector.departmentCreatForm[0]);
            formData.append("id", selector.Id);
            let response = ajaxOperation.SaveAjax("/Department/Update", formData);
            tostrMessage.UpdatedMessage(response);
            response === true ? selector.departmentCreatForm[0].reset() : true;
            selector.tableInformation.fnFilter();
            return response === true ? false : true;
        }
        DeleteData(Id) {
            Swal.fire({
                title: 'Are You Sure?',
                text: "",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes',
                showConfirmButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
            }).then((result) => {
                if (result.value) {
                    let hasDone = ajaxOperation.DeleteAjaxById("/Department/Delete", Id);
                    tostrMessage.DeletedMessage(hasDone);
                    selector.tableInformation.fnFilter();
                }
            });
        }
    }

    let department = new Department();
    let ajaxOperation = new AjaxOperation();
    let tostrMessage = new TostrMessage();

    window.onload = function () {
        department.DepartmentList();
    }

    selector.departmentCreateBtn.click(function () {
        if ($(this).text() === "Save")
            department.SaveData();
        else {
            if (department.UpdateData() === false) {
                selector.departmentCreateBtn.text("Save");
            }
        }
    });

    $(document).on("click", selector.edit, function () {
        selector.Id = $(this).attr("departmentId");
        selector.name.val($(this).attr("name"));
        selector.code.val($(this).attr("code"));
        selector.description.val($(this).attr("description"));
        selector.departmentCreateBtn.text("Update");
    });

    $(document).on("click", selector.delete, function () {
        department.DeleteData($(this).attr("departmentId"));
    });
})();