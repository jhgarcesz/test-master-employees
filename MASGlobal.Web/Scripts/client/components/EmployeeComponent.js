const generateEmployeeRow = (rowData) =>
    `<tr>
        <td>${rowData.id}</td>
        <td>${rowData.name}</td>
        <td>${rowData.roleName}</td>
        <td>${rowData.contractTypeName}</td>
        <td>${formatSalary(rowData.hourlySalary)}</td>
        <td>${formatSalary(rowData.monthlySalary)}</td>
        <td>${formatSalary(rowData.annualSalary)}</td>
    </tr>`;

const formatSalary = (number) => numeral(number).format('$0,0');

const loadEmployees = () => {
    $("#table-body").html("");

    const employeeId = $("#employee-id").val();

    if (!employeeId) {
        employeeService.getAll((data) => {
            if (data) {
                const rows = data.map((e) => {
                    return generateEmployeeRow(e);
                });
                $("#table-body").html(rows);
            }
        });
    } else {
        if (isNaN(employeeId)) {
            alert("Please insert a valid number");
        } else {
            employeeService.getById((data) => {
                if (data) {
                    $("#table-body").html(generateEmployeeRow(data));
                }
            }, employeeId);
        }
    }
};

$(() => {
    $("#search-employees").on("click", () => {
        loadEmployees();
        return false;
    });
});