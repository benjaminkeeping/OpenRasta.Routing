namespace OpenRasta.Routing
{
    public class DeleteAttribute : BaseRouteAttribute
    {
        public DeleteAttribute(string route)
            : base(route)
        {
            Method = "DELETE";
        }
    }
}