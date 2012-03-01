using Machine.Specifications;

namespace OpenRasta.Routing.Specs.attributes
{
    [Behaviors]
    public class should_have_the_expected_http_method : attribute_context
    {
        It should_set_the_http_method = () => theAttribute.Method.ShouldEqual(theExpectedHttpMethod.ToUpper());
    }
}