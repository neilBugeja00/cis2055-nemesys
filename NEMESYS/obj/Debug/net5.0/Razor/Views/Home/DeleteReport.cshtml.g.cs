#pragma checksum "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90decf81cab230558957f13afd9e1c3cfb335ff9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DeleteReport), @"mvc.1.0.view", @"/Views/Home/DeleteReport.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90decf81cab230558957f13afd9e1c3cfb335ff9", @"/Views/Home/DeleteReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ab5a5949b63007e87413bab4c69896099f52b9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_DeleteReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportClass>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
  
    ViewData["Title"] = "Delete Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
        <h3 class=""display-4"">Details</h3>
        <div class=""row"">
            <div class=""col-md-6"">
                <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                    <ol class=""carousel-indicators"">
                        
");
            WriteLiteral(@"
                    </div>
                    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Next</span>
                    </a>
                </div>
            </div>
            <div class=""col-md-6"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <h1>");
#nullable restore
#line 43 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                       Write(Model.ReportTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12 text-primary\">\r\n                        <span class=\"label label-primary\">By: ");
#nullable restore
#line 49 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                         Write(Model.ReporterFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 49 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                  Write(Model.ReporterLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12\">\r\n                        <p class=\"description\">\r\n                            ");
#nullable restore
#line 56 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                       Write(Model.HazardDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </p>
                    </div>
                </div>

                <hr />

                <ul class=""list-group"">
                    <li class=""list-group-item""><span class=""font-weight-bold"">Hazard Type      - </span> ");
#nullable restore
#line 64 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.HazardType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Hazard Photo      - </span> ");
#nullable restore
#line 65 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                      Write(Model.HazardPhoto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Hazard Location  - </span> ");
#nullable restore
#line 66 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.HazardLocation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Hazard Status    - </span> ");
#nullable restore
#line 67 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.HazardStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Hazard Date      - </span> ");
#nullable restore
#line 68 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.HazardDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Reporter Email   - </span> ");
#nullable restore
#line 69 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.ReporterEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Reporter Mobile  - </span> ");
#nullable restore
#line 70 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.ReporterMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Report Date      - </span> ");
#nullable restore
#line 71 "C:\Users\neilb\Desktop\Neil\Web6\Web2\NEMESYS\Views\Home\DeleteReport.cshtml"
                                                                                                     Write(Model.ReportDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    \r\n                </ul>\r\n\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90decf81cab230558957f13afd9e1c3cfb335ff911025", async() => {
                WriteLiteral("\r\n\t<div class=\"form-group\">\r\n              <input type=\"submit\" value=\"Delete\" class=\"btn btn-primary\" href=\"Index\"/>\r\n         </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90decf81cab230558957f13afd9e1c3cfb335ff912720", async() => {
                WriteLiteral("Back to Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportClass> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
