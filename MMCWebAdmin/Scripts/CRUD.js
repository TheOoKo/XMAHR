

function ADD(modalname) {
    $(modalname).modal('show');
    $('.datepicker').datepicker({
        formet: 'mm/dd/yyyy'
    });
}

function EDIT(id, url, div, formid, modalid, modalname) {
    $.ajax(
    {
        url: url,
        data: { id: id },
        beforeSend: function () {
            $(div).empty();
        },
        success: function (data) {
            $(div).empty().html(data);
        },
        complete: function () {
            attachValidator(formid, modalid);
            $(modalname).modal('show');
        }
    })
}

function EDITWITHKEY(id, source, url, div, formid, modalid, modalname) {
    $.ajax(
    {
        url: url,
        data: { id: id, source: source },
        beforeSend: function () {
            $(div).empty();
        },
        success: function (data) {
            $(div).empty().html(data);
        },
        complete: function () {
            attachValidator(formid, modalid);
            $(modalname).modal('show');
        }
    })
}

function DELETE(id, url, div) {
    $.ajax(
    {
        url: url,
        data: { id: id },
        beforeSend: function () {

        },
        success: function (data) {
            $(div + id).empty();
        }
    })
}

function DELETEWITHKEY(id, source, url, div) {
    $.ajax(
    {
        url: url,
        data: { id: id, source: source },
        beforeSend: function () {

        },
        success: function (data) {
            $(div + id).empty();
        }
    })
}

function LIST(url, div) {
    $.ajax({
        url: url,
        beforeSend: function () {
            $(div).innerHTML = "Loading . . . .";
        },
        success: function (myData) {
            $(div).empty().append(myData);
        }
    });
}

//function getStates(state, hstate, township, htownship) {
    
//    $.ajax({
//        url: '@Url.Action("GetStates", "Home")',
//        type: 'Get',
//        cache: false,
//        success: function (result) {
//            $(state).empty();
//            for (i = 0; i < result.length; i++) {
//                $(state).append($('<option></option>').text(result[i]).attr('ID', result[i]));
//            }
//        },
//        complete: function () {
//            $(state).val($(hstate).val());
//            alert($(state).val());
//            $.ajax({
//                url: '@Url.Action("GetTownships","Home")',
//                type: 'Get',
//                cache: false,
//                data: { selectedState: $(hstate).val() },
//                success: function (result) {
//                    $(township).empty();
//                    for (i = 0; i < result.length; i++) {
//                        $(township).append($('<option></option>').text(result[i]).attr('ID', result[i]));
//                    }
//                },
//                complete: function () {
//                    $(township).val($(htownship).val());
//                }
//            })
//        }
//    })
//}