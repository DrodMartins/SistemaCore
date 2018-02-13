using AutoMapper;
using CaracteristicaContext.Api.ViewModels;
using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate;
using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands;
using Core.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CaracteristicaContext.Api.Controllers
{
    public class CaracteristicaController : BaseController
    {
        private readonly ICaracteristicaRepository _caracteristicaRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CaracteristicaController(INotificationHandler<NotificationDomain> notifications,
                                        ICaracteristicaRepository caracteristicaRepository,
                                        IMapper mapper,
                                        IMediator mediator): base(notifications)
        {
            _caracteristicaRepository = caracteristicaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("caracteristica/{id:int}")]
        public async Task<IActionResult> ObterCaracteristicaAsync(int id, int version)
        {
            return Retorno(_mapper.Map<CaracteristicaViewModel>(await _caracteristicaRepository.ObterAsync(id)));
        }

        [HttpPost]
        [Route("caracteristica")]
        public async Task<IActionResult> Post([FromBody]CaracteristicaViewModel caracteristicaViewModel)
        {
            var eventoCommand = _mapper.Map<IncluirCaracteristicaCommand>(caracteristicaViewModel);

            await _mediator.Send(eventoCommand);
           
            return Retorno(eventoCommand);
        }
    }
}