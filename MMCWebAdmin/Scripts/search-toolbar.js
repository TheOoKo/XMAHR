function searchToolbar(action, targetUpdateList, labelStatus, args) {
    this.action = action;
    this.targetupdateList = '#' + targetUpdateList;
    this.labelStatus = '#' + labelStatus;
    this.toolbarId = '#searchQuery';
    if (args != null) {
        //if (args.companyId != null) {
        //    this.companyId = args.companyId;
        //}
        //if (args.agencyName != null) {
        //    this.agencyName = args.agencyName;
        //}
        //if (args.crewId != null) {
        //    this.crewId = args.crewId;
        //}
        //if (args.agencyId != null) {
        //    this.agencyId = args.agencyId;
        //}
        if (args.toolbarId != null) {
            this.toolbarId = "#" + args.toolbarId;
        }
    }

    this.initialize = function () {
        var parent = this;
        var $toolbar = $(this.toolbarId);
        $('#mySelectlist').selectlist('selectByIndex', '1');
        $('#mySortlist').selectlist('selectByIndex', '1');
        $('#mySearch').search();
        $('#mySearch').on('searched.fu.search', function () {
            $toolbar.data('searchvalue', $('#searchInput').val());
            $toolbar.data('searchterm', $('#mySelectListInput').val());
            parent.updateList();
        });

        $('#mySearch').on('cleared.fu.search', function () {
            $toolbar.data('searchterm', '*');
            $toolbar.data('searchvalue', '*');
            parent.updateList();
        });
        $(document).on('click', '.pagination a', function (e) {
            e.preventDefault();
            $toolbar.data('action', $(this).attr("href"));
            parent.updateList();
        });
        $(document).on('click', '.btn-tag button', function (e) {
            $toolbar.data('tag-searchvalue', $(this).data('tagsearchvalue'));
            $toolbar.data('tag-searchterm', $(this).data('tagsearchterm'));
            if ($(this).data('tagsearchterm') === "*") {
                $toolbar.data('searchterm', '*');
                $toolbar.data('searchvalue', '*');
                $('#searchInput').val("");
                $('#btnMySearch').removeClass('glyphicon-remove').addClass('glyphicon-search');
            };
            parent.updateList();

        });
        $('#mySortlist').on('changed.fu.selectlist', function () {
            $toolbar.data('sortby', $('#mySortListInput').val());
            $toolbar.data('sortdirection', 'asc');
            parent.updateList();
        });
        $toolbar.data('action', this.action);
    };
    this.updateAction = function () {
        var $toolbar = $(this.toolbarId);
        $toolbar.data('action', this.action);
    }
    this.updateList = function () {

        var $toolbar = $(this.toolbarId);
        var target = this.targetupdateList;
        var lblstatus = this.labelStatus;
        var paras = {};
        //if (this.companyId != null) {
        //    paras.companyId = this.companyId;
        //}
        //if (this.agencyName != null) {
        //    paras.agencyName = this.agencyName;
        //}
        //if (this.crewId != null) {
        //    paras.crewId = this.crewId;
        //}
        //if (this.agencyId != null) {
        //    paras.agencyId = this.agencyId;
        //}

        paras.searchTerm = $toolbar.data('searchterm');
        paras.searchValue = $toolbar.data('searchvalue');
        paras.tagsearchTerm = $toolbar.data('tag-searchterm');
        paras.tagsearchValue = $toolbar.data('tag-searchvalue');
        paras.sortBy = $toolbar.data('sortby');
        paras.sortDirection = $toolbar.data('sortdirection');
        $.ajax({
            url: $toolbar.data('action'),
            data: paras,
            type: "get",
            beforeSend: function () {
                //alert('');
                //$('#alertBox').css('display', 'none');
                $("#lblStatus").empty().html("<strong>Loading...</strong>");
                $(".indicator").addClass("show");
            },
            success: function (myData) {
                if (myData === 'TYPEERROR') {
                    //$('#alertBox').css('display', 'block');
                    $(lblstatus).empty().html("<strong>Search Error!</strong> Entered search query is invalid.");
                }
                else {

                    $(target).empty().append(myData);
                }
            },
            complete: function () {
                $(".indicator").removeClass("show");
            }
        });
    };

}