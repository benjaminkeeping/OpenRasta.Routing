using Machine.Specifications;

namespace OpenRasta.Routing.Specs.attributes
{
    [Subject(typeof(PatchAttribute))]
    public class given_a_patch_attribute : attribute_context
    {
        Establish context = () =>
        {
            theExpectedHttpMethod = "patch";
            theAttribute = new PatchAttribute("a route");
        };

        Behaves_like<should_have_the_expected_http_method> should_have_the_expected_http_method;
    }

}