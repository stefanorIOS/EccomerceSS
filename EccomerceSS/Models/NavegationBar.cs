namespace EccomerceSS.Models
{
    public class NavegationBar : BaseClass
    {
        public string text { get; set; }
        public string actionMethod { get; set; }
        public string controllerMethod { get; set; }
        public string rolRequiredToAccess { get; set; }
    }
}
