using AutoMapper;
using CaracteristicaContext.Api.ViewModels;
using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands;

namespace CaracteristicaContext.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CaracteristicaViewModel, IncluirCaracteristicaCommand>()
                .ConstructUsing(c=> new IncluirCaracteristicaCommand(c.Nome, c.Descricao));
        }
    }
}
