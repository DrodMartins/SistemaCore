using AutoMapper;
using CaracteristicaContext.Api.ViewModels;
using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate;

namespace CaracteristicaContext.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Caracteristica, CaracteristicaViewModel>();
        }
    }
}
