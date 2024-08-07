namespace MecaAgenda.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryMailer
    {
        void SendEmail(string subject, string body, List<string> to);
    }
}
