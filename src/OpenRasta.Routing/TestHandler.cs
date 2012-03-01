using System;
using OpenRasta.Web;

namespace OpenRasta.Routing
{
    public class TestHandler
    {
        [Get("/my/get/route")]
        public OperationResult Get(Guid productId)
        {
            return null;
        }
    }
}