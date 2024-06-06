namespace MecaAgenda.Web.Models
{
    public class ErrorMiddlewareViewModel
    {
        public String Path { get; set; } = default!;
        public List<String> ListMessages { get; set; } = default!;
        public String IdEvent { get; set; } = default!;
    }
}
