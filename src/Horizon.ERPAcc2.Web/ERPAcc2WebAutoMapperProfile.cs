using Horizon.ERPAcc2.Web.Pages.FiscalYearPeriods;
using Horizon.ERPAcc2.FiscalYearPeriods;
using Horizon.ERPAcc2.Web.Pages.FiscalYears;
using Horizon.ERPAcc2.FiscalYears;

using Horizon.ERPAcc2.Web.Pages.FiscalYearStatuses;
using Volo.Abp.AutoMapper;
using Horizon.ERPAcc2.FiscalYearStatuses;
using AutoMapper;

namespace Horizon.ERPAcc2.Web;

public class ERPAcc2WebAutoMapperProfile : Profile
{
    public ERPAcc2WebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project

        CreateMap<FiscalYearStatusDto, FiscalYearStatusUpdateViewModel>();
        CreateMap<FiscalYearStatusUpdateViewModel, FiscalYearStatusUpdateDto>();
        CreateMap<FiscalYearStatusCreateViewModel, FiscalYearStatusCreateDto>();

        CreateMap<FiscalYearDto, FiscalYearUpdateViewModel>();
        CreateMap<FiscalYearUpdateViewModel, FiscalYearUpdateDto>();
        CreateMap<FiscalYearCreateViewModel, FiscalYearCreateDto>();

        CreateMap<FiscalYearPeriodDto, FiscalYearPeriodUpdateViewModel>();
        CreateMap<FiscalYearPeriodUpdateViewModel, FiscalYearPeriodUpdateDto>();
        CreateMap<FiscalYearPeriodCreateViewModel, FiscalYearPeriodCreateDto>();
    }
}