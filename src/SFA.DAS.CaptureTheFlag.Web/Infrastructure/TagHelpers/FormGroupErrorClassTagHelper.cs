using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Text.Encodings.Web;

namespace DAS_Capture_The_Flag.Infrastructure.TagHelpers
{
    [HtmlTargetElement(Attributes = "sfa-gds-error-class-for-name")]
    public class FormGroupErrorClassForNameTagHelper : TagHelper
    {
        public const string ValidationForNameAttributeName = "sfa-gds-error-class-for-name";

        [HtmlAttributeName(ValidationForNameAttributeName)]
        public string ForName { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ModelStateEntry entry;
            ViewContext.ViewData.ModelState.TryGetValue(ForName, out entry);
            if (entry == null || !entry.Errors.Any()) return;

            output.Attributes.RemoveAll("sfa-gds-error-class");
            output.AddClass("govuk-form-group--error", HtmlEncoder.Default);
        }
    }

    [HtmlTargetElement(Attributes = "sfa-gds-error-class-for")]
    public class FormGroupErrorClassTagHelper : TagHelper
    {
        public const string ValidationForAttributeName = "sfa-gds-error-class-for";

        [HtmlAttributeName(ValidationForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            ModelStateEntry entry;
            ViewContext.ViewData.ModelState.TryGetValue(For.Name, out entry);
            if (entry == null || !entry.Errors.Any()) return;

            output.Attributes.RemoveAll("sfa-gds-error-class");
            output.AddClass("govuk-form-group--error", HtmlEncoder.Default);
        }
    }
}
