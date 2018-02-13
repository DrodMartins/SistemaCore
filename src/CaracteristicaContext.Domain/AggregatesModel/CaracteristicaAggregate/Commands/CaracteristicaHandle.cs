using Core.Domain.Notification;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands
{
    public class CaracteristicaHandle : IRequestHandler<IncluirCaracteristicaCommand>
    {
        private readonly ICaracteristicaRepository _caracteristicaRepository;
        private readonly NotificationHandle _notifications;
        private readonly IMediator _mediator;

        public CaracteristicaHandle(ICaracteristicaRepository caracteristicaRepository,
                                     INotificationHandler<NotificationDomain> notifications,
                                     IMediator mediator)
        {
            _caracteristicaRepository = caracteristicaRepository;
            _notifications = (NotificationHandle)notifications;
            _mediator = mediator;
        }

        public Task Handle(IncluirCaracteristicaCommand notification, CancellationToken cancellationToken)
        {
            var caracteristica = new Caracteristica(notification.Nome, notification.Descricao);

            if (!caracteristica.SeValido())
            {
                NotificarValidacoesErro(caracteristica.ValidationResult);
                return Task.CompletedTask;
            }

            _caracteristicaRepository.IncluirAsync(caracteristica);
            return Task.CompletedTask;
        }

        private void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.Publish(new NotificationDomain(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}
