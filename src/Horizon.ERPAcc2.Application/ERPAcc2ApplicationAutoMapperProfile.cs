using Horizon.ERPAcc2.FiscalYearPeriods;
using Horizon.ERPAcc2.FiscalYears;

using System;
using Horizon.ERPAcc2.Shared;
using Volo.Abp.AutoMapper;
using Horizon.ERPAcc2.FiscalYearStatuses;
using AutoMapper;

namespace Horizon.ERPAcc2;

public class ERPAcc2ApplicationAutoMapperProfile : Profile
{
    public ERPAcc2ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<FiscalYearStatus, FiscalYearStatusDto>();
        CreateMap<FiscalYearStatus, FiscalYearStatusExcelDto>();

        CreateMap<FiscalYear, FiscalYearDto>();
        CreateMap<FiscalYear, FiscalYearExcelDto>();
        CreateMap<FiscalYearWithNavigationProperties, FiscalYearWithNavigationPropertiesDto>();
        CreateMap<FiscalYearStatus, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.FiscalYearStatusTitle));

        CreateMap<FiscalYearPeriod, FiscalYearPeriodDto>();
    }
}