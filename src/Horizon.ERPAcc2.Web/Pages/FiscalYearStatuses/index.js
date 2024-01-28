$(function () {
    var l = abp.localization.getResource("ERPAcc2");
	
	var fiscalYearStatusService = window.horizon.eRPAcc2.fiscalYearStatuses.fiscalYearStatuses;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "FiscalYearStatuses/CreateModal",
        scriptUrl: abp.appPath + "Pages/FiscalYearStatuses/createModal.js",
        modalClass: "fiscalYearStatusCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "FiscalYearStatuses/EditModal",
        scriptUrl: abp.appPath + "Pages/FiscalYearStatuses/editModal.js",
        modalClass: "fiscalYearStatusEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            fiscalYearStatusTitle: $("#FiscalYearStatusTitleFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>
    
    var dataTableColumns = [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('ERPAcc2.FiscalYearStatuses.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('ERPAcc2.FiscalYearStatuses.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    fiscalYearStatusService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                },
                width: "1rem"
            },
			{ data: "fiscalYearStatusTitle" }        
    ];
    
    

    var dataTable = $("#FiscalYearStatusesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(fiscalYearStatusService.getList, getFilter),
        columnDefs: dataTableColumns
    }));
    
    //<suite-custom-code-block-2>
    //</suite-custom-code-block-2>

    createModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    editModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    $("#NewFiscalYearStatusButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        fiscalYearStatusService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/fiscal-year-statuses/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'fiscalYearStatusTitle', value: input.fiscalYearStatusTitle }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reloadEx();;
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reloadEx();;
    });
    
    //<suite-custom-code-block-3>
    //</suite-custom-code-block-3>
    
    
    
    
    
    
});
