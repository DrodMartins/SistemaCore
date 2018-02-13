namespace Core.Domain.Notification
{
    public class NotificationDomain : Event
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }

        public NotificationDomain(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }
    }
}
