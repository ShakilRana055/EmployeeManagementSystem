
(function () {
    let selector = {
        employeeList: $("#employeeList"),
        tableInformation: '',
        label: [],
        departmentCount: [],
        backgroundColor: [],
    }

    let ajaxOperation = new AjaxOperation();

    function EmployeeList() {
        var employeeList = selector.employeeList.dataTable({
            "processing": true,
            "serverSide": true,
            "filter": true,
            "pageLength": 10,
            "autoWidth": false,
            "lengthMenu": [[10, 50, 100, 500, 1000, 10000], [10, 50, 100, 500, 1000, 10000]],
            "order": [[0, "desc"]],
            "ajax": {
                "url": "/Employee/GetEmployeeList/",
                "type": "POST",
                "data": function (data) {
                },
                "complete": function (json) {
                }
            },
            "columnDefs": [
                { "className": "textAlign", "targets": [1, 2, 3, 4] },
                { "className": "leftAlign", "targets": [0] },
            ],
            "columns": [
                {
                    "render": function (data, type, full, meta) {
                        return `Id:${full.employeeId} <br />
                                Name:${full.name} <br />
                                Designation:${full.designation} <br />
                                Dept. Name:${full.department.name} <br />
                                Phone:${full.phone} <br />
                                `;
                    }
                },
                {
                    "render": function (data, type, full, meta) {
                        return `<img src="${full.photoUrl}" alt="Image" width="40" height="50" />`
                    }
                },
                { "data": "salaryStructure.grossSalary", "name": "salaryStructure.grossSalary", "autowidth": true, "orderable": true },
                
                {
                    "render": function (data, type, full, meta) {
                        return Status(full.employeeStatus);
                    }
                },
                {
                    "render": function (data, type, full, meta) {
                        return `
                                <div class="btn-group">
                                    <i class="fa fa-ellipsis-h" title = 'Actions' style = 'cursor:pointer;' data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i>
                                  <div class="dropdown-menu" >
                                    <button style="font-size: inherit;" class="dropdown-item btn-rx editEmployee" employeeId = "${full.employeeId}" ><i class="fa fa-check-circle" aria-hidden="true"></i>Edit</button >
                                    <button style="font-size: inherit;" class="dropdown-item btn-rx deleteEmployee" employeeId = "${full.employeeId}" > <i class="fa fa-times" aria-hidden="true"></i>Delete</button >
                                  </div>
                                </div>`;
                    }
                },
            ]
        });
        selector.tableInformation = employeeList;
    }

    function Status(code) {
        if (code === 1)
            return `<span class ="badge badge-primary">Loading</span>`;
        else if (code === 2)
            return `<span class ="badge badge-success">Active</span>`;
        else if (code === 3)
            return `<span class ="badge badge-dark">Deactive</span>`;
        else if (code === 4)
            return `<span class ="badge badge-warning">New</span>`;
        else if (code === 5)
            return `<span class ="badge badge-info">Old</span>`;
        else if (code === 6)
            return `<span class ="badge badge-danger">Resigned</span>`;
    }

    function ChartInformation() {
        let response = ajaxOperation.GetAjax("/Employee/EmployeePieChart");
        let backgroundColor = ['red', 'orange', 'yellow', 'green', 'brown', 'blue', 'purple', 'pink', 'teal'];
        let i = 0;
        for (var item in response) {
            selector.label.push(item);
            selector.departmentCount.push(response[item]);
            selector.backgroundColor.push(backgroundColor[i++]);
        }
        EmployeePieChart();
    }

    function EmployeePieChart() {
        var ctx = document.getElementById('employeePieChart').getContext('2d');
        var chart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: selector.label,
                datasets: [{
                    backgroundColor: selector.backgroundColor,
                    data: selector.departmentCount,
                }]
            },
            options: {
                animation: {
                    animateScale: true
                }
            }
        });
    }

    window.onload = function () {
        EmployeeList();
        ChartInformation();
    }

})();
