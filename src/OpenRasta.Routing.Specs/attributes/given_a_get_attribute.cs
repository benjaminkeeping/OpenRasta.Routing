using Machine.Specifications;

namespace OpenRasta.Routing.Specs.attributes
{
    [Subject(typeof(GetAttribute))]
    public class given_a_get_attribute : attribute_context
    {
        Establish context = () =>
        {
            theExpectedHttpMethod = "get";
            theAttribute = new GetAttribute("a route");
        };

        Behaves_like<should_have_the_expected_http_method> should_have_the_expected_http_method;
    }
}