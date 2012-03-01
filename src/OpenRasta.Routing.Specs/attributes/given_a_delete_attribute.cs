using Machine.Specifications;

namespace OpenRasta.Routing.Specs.attributes
{
    [Subject(typeof(DeleteAttribute))]
    public class given_a_delete_attribute : attribute_context
    {
        Establish context = () =>
        {
            theExpectedHttpMethod = "delete";
            theAttribute = new DeleteAttribute("a route");
        };

        Behaves_like<should_have_the_expected_http_method> should_have_the_expected_http_method;
    }
}