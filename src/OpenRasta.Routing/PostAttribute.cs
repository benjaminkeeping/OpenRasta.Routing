namespace OpenRasta.Routing
{
    public class PostAttribute : BaseRouteAttribute
    {
        public PostAttribute(string route)
            : base(route)
        {
            Method = "POST";
        }
    }
}