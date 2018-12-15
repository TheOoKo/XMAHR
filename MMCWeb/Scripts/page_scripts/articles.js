$(function () {

    showPhotoPlaceHolder();

    $("#article_photo").kendoUpload({
        async: {
            saveUrl: '/PhotoUpload/uploadArticlePhoto',
            autoUpload: true
        },
        upload: function (e) {
            e.data = { aid: $("#hdn_article").val() }
        },
        complete: onComplete,
        success: onSuccess,
        error: onError
    });

    $("button[type='reset']").click(function () {

        showPhotoPlaceHolder();

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
                //$("button[type='reset']").click();
                $("#grid").data("kendoGrid").dataSource.read();
                $("#hdn_article").val(data.ID)
                showPhotoList(data.ID)

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
                    url: '/Admin/getAllArticles',
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
                field: "Title",
                title: "Title",
                filterable: false,
                width: 200
            },
            {
                field: "IsPublished",
                title: "Published",
                filterable: false,
                template: '<input class = "p_active" type="checkbox" #= IsPublished ? "checked=checked" : "" #  ></input>',
                width: 40
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

    $("#grid").on("change", ".p_active", function (e) {
        var row = $(e.target).closest("tr");
        var item = $("#grid").data("kendoGrid").dataItem(row);
        if ($(this).is(':checked')) {
            articleChangeActiveStatus(item.ID, true);
        }
        else {
            articleChangeActiveStatus(item.ID, false);
        }
    });

    $('body').on('click', '#btn_photo', function (e) {

        e.preventDefault();

        var id = $(this).attr('data-photo-id');

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
                url: '/PhotoUpload/deleteArticlePhoto',
                data: { pId: id },
                beforeSend: function () {
                },
                success: function (myData) {

                    swal({
                        title: "Successfully deleted!",
                        text: "I will close in 2 seconds.",
                        confirmButtonColor: "#2196F3",
                        timer: 2000
                    });

                    showPhotoList($("#hdn_article").val());

                }
            });

        });

    });

});

function articleChangeActiveStatus(id, status) {

    var light = $("#grid").parent();

    $.ajax({
        url: '/Admin/changeArticleStatus',
        data: { aid: id, aStatus: status },
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
        success: function (myData) {

            $(light).unblock();

        }
    });
}

function showDetails(e) {
    e.preventDefault();

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    $("input[name='Title']").val(dataItem.Title);
    $("input[name='ID']").val(dataItem.ID);
    $("textarea[name='Body']").val(dataItem.Body);
    $("#hdn_article").val(dataItem.ID)
    showPhotoList(dataItem.ID);
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
            url: '/Admin/articleDelete',
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

function showPhotoPlaceHolder() {

    $("#hdn_form_art_id").val(0);
    $("#hdn_article").val("")
    $("#photo_list").css("display", "none");
    $("#photo_placeholder").css("display", "block");
    $("#photoResult").empty();
}

function showPhotoList(v) {
    $("#photo_placeholder").css("display", "none");
    $("#photo_list").css("display", "block");

    $("#photoResult").empty();
    $.ajax({
        url: '/Admin/getPhotoListByArticleId',
        data: { aid: v },
        beforeSend: function () {
        },
        success: function (myData) {

            for (var v = 0; v < myData.length; v++) {
               
                $("#photoResult").append("<div style = \"position: relative;\"><img style = \"width: 50px;\" src = \"https://portalvhdslvb28rs1c3tmc.blob.core.windows.net/mmc/photo/" + myData[v].PhotoURL + "\" /><button style = \"position: absolute; top: 0; right: 0;\" id = \"btn_photo\" data-photo-id = \"" + myData[v].ID + "\" class = \"btn btn-xs btn-danger\" id = \"btn_image\"><span class=\"icon-trash\"></span></button></div> <br>");
            }

        }
    });

}

function onComplete(e) {
    showPhotoList($("#hdn_article").val());
}

function onSuccess(e) {

}

function onError(e) {

}