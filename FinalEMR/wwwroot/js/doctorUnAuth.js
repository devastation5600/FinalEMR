var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Doctor/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "emailAddress", "width": "20%" },
            { "data": "streetAddress", "width": "20%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "5%" }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}