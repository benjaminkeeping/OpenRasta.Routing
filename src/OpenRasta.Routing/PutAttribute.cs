namespace OpenRasta.Routing
{
    public class PutAttribute : BaseRouteAttribute
    {
        public PutAttribute(string route)
            : base(route, "PUT")
        {
        }
    }
}