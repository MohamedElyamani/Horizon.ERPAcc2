$(function () {
    var l = abp.localization.getResource("ERPAcc2");
	
	var fiscalYearService = window.horizon.eRPAcc2.fiscalYears.fiscalYears;
	
        var lastNpIdId = '';
        var lastNpDisplayNameId = '';

        var _lookupModal = new abp.ModalManager({
            viewUrl: abp.appPath + "Shared/LookupModal",
            scriptUrl: abp.appPath + "Pages/Shared/lookupModal.js",
            modalClass: "navigationPropertyLookup"
        });

        $('.lookupCleanButton').on('click', '', function () {
            $(this).parent().find('input').val('');
        });

        _lookupModal.onClose(function () {
            var modal = $(_lookupModal.getModal());
            $('#' + lastNpIdId).val(modal.find('#CurrentLookupId').val());
            $('#' + lastNpDisplayNameId).val(modal.find('#CurrentLookupDisplayName').val());
        });
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "FiscalYears/CreateModal",
        scriptUrl: abp.appPath + "Pages/FiscalYears/createModal.js",
        modalClass: "fiscalYearCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "FiscalYears/EditModal",
        scriptUrl: abp.appPath + "Pages/FiscalYears/editModal.js",
        modalClass: "fiscalYearEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            fiscalYearName: $("#FiscalYearNameFilter").val(),
			startDateMin: $("#StartDateFilterMin").val(),
			startDateMax: $("#StartDateFilterMax").val(),
			endDateMin: $("#EndDateFilterMin").val(),
			endDateMax: $("#EndDateFilterMax").val(),
			lockDateMin: $("#LockDateFilterMin").val(),
			lockDateMax: $("#LockDateFilterMax").val(),
			calanderYearMin: $("#CalanderYearFilterMin").val(),
			calanderYearMax: $("#CalanderYearFilterMax").val(),
			yearEndMonthMin: $("#YearEndMonthFilterMin").val(),
			yearEndMonthMax: $("#YearEndMonthFilterMax").val(),
			yearEndDayMin: $("#YearEndDayFilterMin").val(),
			yearEndDayMax: $("#YearEndDayFilterMax").val(),
            isCurrent: (function () {
                var value = $("#IsCurrentFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
            isLocked: (function () {
                var value = $("#IsLockedFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			noOfPeriodsMin: $("#NoOfPeriodsFilterMin").val(),
			noOfPeriodsMax: $("#NoOfPeriodsFilterMax").val(),
			periodInterval: $("#PeriodIntervalFilter").val(),
			fiscalYearStatusId: $("#FiscalYearStatusIdFilter").val()
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
                                visible: abp.auth.isGranted('ERPAcc2.FiscalYears.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.fiscalYear.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('ERPAcc2.FiscalYears.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    fiscalYearService.delete(data.record.fiscalYear.id)
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
			{ data: "fiscalYear.fiscalYearName" },
            {
                data: "fiscalYear.startDate",
                render: function (startDate) {
                    if (!startDate) {
                        return "";
                    }
                    
					var date = Date.parse(startDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "fiscalYear.endDate",
                render: function (endDate) {
                    if (!endDate) {
                        return "";
                    }
                    
					var date = Date.parse(endDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "fiscalYear.lockDate",
                render: function (lockDate) {
                    if (!lockDate) {
                        return "";
                    }
                    
					var date = Date.parse(lockDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "fiscalYear.calanderYear" },
			{ data: "fiscalYear.yearEndMonth" },
			{ data: "fiscalYear.yearEndDay" },
            {
                data: "fiscalYear.isCurrent",
                render: function (isCurrent) {
                    return isCurrent ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
            {
                data: "fiscalYear.isLocked",
                render: function (isLocked) {
                    return isLocked ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
			{ data: "fiscalYear.noOfPeriods" },
			{ data: "fiscalYear.periodInterval" },
            {
                data: "fiscalYearStatus.fiscalYearStatusId",
                defaultContent : ""
            }        
    ];
    
        var showDetailRows = abp.auth.isGranted('ERPAcc2.FiscalYearPeriods') ;
    if(showDetailRows) {
        dataTableColumns.unshift({
            class: "details-control text-center",
            orderable: false,
            data: null,
            defaultContent: '<i class="fa fa-chevron-down"></i>',
            width: "0.1rem"
        });
    }
    else {
        $("#DetailRowTHeader").remove();
    }

    var dataTable = $("#FiscalYearsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(fiscalYearService.getList, getFilter),
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

    $("#NewFiscalYearButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        fiscalYearService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/fiscal-years/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'fiscalYearName', value: input.fiscalYearName },
                            { name: 'startDateMin', value: input.startDateMin },
                            { name: 'startDateMax', value: input.startDateMax },
                            { name: 'endDateMin', value: input.endDateMin },
                            { name: 'endDateMax', value: input.endDateMax },
                            { name: 'lockDateMin', value: input.lockDateMin },
                            { name: 'lockDateMax', value: input.lockDateMax },
                            { name: 'calanderYearMin', value: input.calanderYearMin },
                            { name: 'calanderYearMax', value: input.calanderYearMax },
                            { name: 'yearEndMonthMin', value: input.yearEndMonthMin },
                            { name: 'yearEndMonthMax', value: input.yearEndMonthMax },
                            { name: 'yearEndDayMin', value: input.yearEndDayMin },
                            { name: 'yearEndDayMax', value: input.yearEndDayMax }, 
                            { name: 'isCurrent', value: input.isCurrent }, 
                            { name: 'isLocked', value: input.isLocked },
                            { name: 'noOfPeriodsMin', value: input.noOfPeriodsMin },
                            { name: 'noOfPeriodsMax', value: input.noOfPeriodsMax }, 
                            { name: 'periodInterval', value: input.periodInterval }, 
                            { name: 'fiscalYearStatusId', value: input.fiscalYearStatusId }
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
    
    
    
        $('#FiscalYearsTable').on('click', 'td.details-control', function () {
        $(this).find("i").toggleClass("fa-chevron-down").toggleClass("fa-chevron-up");
        
        var tr = $(this).parents('tr');
        var row = dataTable.row(tr);

        if (row.child.isShown()) {
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            var data = row.data();
            
            detailRows(data)
                .done(function (result) {
                    row.child(result).show();
                    initDataGrids(data);
                });

            tr.addClass('shown');
        }
    } );

    function detailRows (data) {
        return $.ajax(abp.appPath + "FiscalYears/ChildDataGrid?fiscalYearId=" + data.fiscalYear.id)
            .done(function (result) {
                return result;
            });
    }
    
    function initDataGrids(data) {
        initFiscalYearPeriodGrid(data)
    }
    
        function initFiscalYearPeriodGrid(data) {
        if(!abp.auth.isGranted("ERPAcc2.FiscalYearPeriods")) {
            return;
        }
        
        var fiscalYearId = data.fiscalYear.id;

        
        var fiscalYearPeriodService = window.horizon.eRPAcc2.fiscalYearPeriods.fiscalYearPeriods;

        var fiscalYearPeriodCreateModal = new abp.ModalManager({
            viewUrl: abp.appPath + "FiscalYearPeriods/CreateModal",
            scriptUrl: abp.appPath + "Pages/FiscalYearPeriods/createModal.js",
            modalClass: "fiscalYearPeriodCreate"
        });

        var fiscalYearPeriodEditModal = new abp.ModalManager({
            viewUrl: abp.appPath + "FiscalYearPeriods/EditModal",
            scriptUrl: abp.appPath + "Pages/FiscalYearPeriods/editModal.js",
            modalClass: "fiscalYearPeriodEdit"
        });

        var fiscalYearPeriodDataTable = $("#FiscalYearPeriodsTable-" + fiscalYearId).DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            autoWidth: true,
            scrollCollapse: true,
            order: [[1, "asc"]],
            ajax: abp.libs.datatables.createAjax(fiscalYearPeriodService.getListByFiscalYearId, {
                fiscalYearId: fiscalYearId,
                maxResultCount: 5
            }),
            columnDefs: [
                {
                    rowAction: {
                        items:
                            [
                                {
                                    text: l("Edit"),
                                    visible: abp.auth.isGranted('ERPAcc2.FiscalYearPeriods.Edit'),
                                    action: function (data) {
                                        fiscalYearPeriodEditModal.open({
                                            id: data.record.id
                                        });
                                    }
                                },
                                {
                                    text: l("Delete"),
                                    visible: abp.auth.isGranted('ERPAcc2.FiscalYearPeriods.Delete'),
                                    confirmMessage: function () {
                                        return l("DeleteConfirmationMessage");
                                    },
                                    action: function (data) {
                                        fiscalYearPeriodService.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l("SuccessfullyDeleted"));
                                                fiscalYearPeriodDataTable.ajax.reloadEx();
                                            });
                                    }
                                }
                            ]
                    },
                    width: "1rem"
                },
                { data: "periodName" },
			{ data: "companyId" },
            {
                data: "startDate",
                render: function (startDate) {
                    if (!startDate) {
                        return "";
                    }
                    
					var date = Date.parse(startDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "endDate",
                render: function (endDate) {
                    if (!endDate) {
                        return "";
                    }
                    
					var date = Date.parse(endDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "periodStatusId" },
            {
                data: "isClosed",
                render: function (isClosed) {
                    return isClosed ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
            {
                data: "closeDate",
                render: function (closeDate) {
                    if (!closeDate) {
                        return "";
                    }
                    
					var date = Date.parse(closeDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "totalDepit" },
			{ data: "totalCredit" },
			{ data: "closingBalance" },
			{ data: "beginingInventory" },
			{ data: "purchases" },
			{ data: "endiningInventory" },
			{ data: "cogs" }
            ]
        }));

        fiscalYearPeriodCreateModal.onResult(function () {
            fiscalYearPeriodDataTable.ajax.reloadEx();
        });

        fiscalYearPeriodEditModal.onResult(function () {
            fiscalYearPeriodDataTable.ajax.reloadEx();
        });

        $("#NewFiscalYearPeriodButton").click(function (e) {
            e.preventDefault();
            alert($(this).data("fiscalYear-id"))
            fiscalYearPeriodCreateModal.open({
                fiscalYearId: $(this).data("fiscalYear-id")
            });
        });
    }
});
