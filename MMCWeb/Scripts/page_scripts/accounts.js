$(function () {

    $("button[type='reset']").click(function () {

        $("#hdn_form_acc_id").val(0);
    });

    $("#article_form").submit(function (e) {
        e.preventDefault();

        var light = $(this).parent();

        $.ajax(
        {
            cache: false,
            async: true,
            type: "POST",
            url: $(this).attr('action'),
            data: $(this).serialize(),
            beforeSend: function () {

                $(light).block({
                    message: '<i class="icon-spinner spinner"></i>',
                    overlayCSS: {
                        backgroundColor: '#fff',
                        opacity: 0.8,
                        cursor: 'wait'
                    },
                    css: {
                        border: 0,
                        padding: 0,
                        backgroundColor: 'none'
                    }
                });

            },
            success: function (data) {

                $(light).unblock();
                $("button[type='reset']").click();
                $("#grid").data("kendoGrid").dataSource.read();
                $("#hdn_article").val(data.ID)

            },
            complete: function () {


            }
        }
        );
    });

    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: '/Admin/getAllAccounts',
                    dataType: "json"
                }
            },
            schema: {
                data: "data",
                total: "total"
            },
            pageSize: 10,
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true
        },
        height: 300,
        columns: [
            {
                field: "ID",
                title: "ID",
                filterable: false,
                width: 30
            },
            {
                field: "Name",
                title: "Name",
                filterable: false,
                width: 200
            },
            { command: { text: "Detail", click: showDetails }, width: 40 },
            { command: { text: "Delete", click: deleteArticle }, width: 40 }
        ],
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        filterable: true
    });

});

function showDetails(e) {
    e.preventDefault();

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    $("input[name='Name']").val(dataItem.Name);
    $("input[name='Username']").val(dataItem.Username);
    $("input[name='Password']").val(dataItem.Password);
    $("#selectRole").val(dataItem.Role);
    $("input[name='Email']").val(dataItem.Email);
    $("input[name='Phone']").val(dataItem.Phone);
    $("input[name='ID']").val(dataItem.ID);
}

function deleteArticle(e) {
    e.preventDefault();

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    swal({
        title: "Confirm",
        text: "Are you sure want to delete ?",
        showCancelButton: true,
        closeOnConfirm: false,
        confirmButtonColor: "#EF5350",
        showLoaderOnConfirm: true
    },
    function () {
        $.ajax({
            url: '/Admin/accountDelete',
            data: { aid: dataItem.ID },
            beforeSend: function () {
            },
            success: function (myData) {

                swal({
                    title: "Successfully deleted!",
                    text: "I will close in 2 seconds.",
                    confirmButtonColor: "#2196F3",
                    timer: 2000
                });

                $("#grid").data("kendoGrid").dataSource.read();

            }
        });

    });

}