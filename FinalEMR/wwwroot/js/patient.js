﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Patient/GetAll"
        },
        "columns": [
            { "data": "firstName", "width": "12%" },
            { "data": "lastName", "width": "12%" },
            { "data": "dateOfBirth", "width": "16%" },
            { "data": "height", "width": "8%" },
            { "data": "weight", "width": "8%" },
            { "data": "prescription.name", "width": "12%" },
            { "data": "comments", "width": "10%" },
            { "data": "allergy.name", "width": "8%" },
            { "data": "doctor.name", "width": "10%" },
            { "data": "nurse.name", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Patient/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>  
                                </a>
                                <a onclick=Delete("/Admin/Patient/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "12%"
            }
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