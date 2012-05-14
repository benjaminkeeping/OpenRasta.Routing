namespace OpenRasta.Routing
{
    public class PatchAttribute : BaseRouteAttribute
    {
        public PatchAttribute(string route)
            : base(route, "PATCH")
        {
        }
    }
}