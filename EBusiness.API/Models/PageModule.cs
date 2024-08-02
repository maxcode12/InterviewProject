namespace EBusiness.API.Models
{
    public class PageModule 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Module { get; set; }
        public string Page { get; set; }
    }
}
