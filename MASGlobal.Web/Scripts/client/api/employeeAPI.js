const baseUrl = "http://localhost:50428/api/employees";

const employeeService = {
    getAll: (callback) =>
        $.getJSON(baseUrl)
            .done((data) => callback(data)),
    getById: function(callback, employeeId) {
        $.getJSON(`${baseUrl}/${employeeId}`)
            .done((data) =>  callback(data));
    }
};