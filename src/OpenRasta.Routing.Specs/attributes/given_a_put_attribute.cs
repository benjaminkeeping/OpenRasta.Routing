using Machine.Specifications;

namespace OpenRasta.Routing.Specs.attributes
{
    [Subject(typeof(PutAttribute))]
    public class given_a_put_attribute : attribute_context
    {
        Establish context = () =>
        {
            theExpectedHttpMethod = "put";
            theAttribute = new PutAttribute("a route");
        };

        Behaves_like<should_have_the_expected_http_method> should_have_the_expected_http_method;
    }
}