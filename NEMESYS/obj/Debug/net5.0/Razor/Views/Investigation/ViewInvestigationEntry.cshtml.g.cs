#pragma checksum "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa7e767ce4b3e8389e98274a16805d7e42ef075d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Investigation_ViewInvestigationEntry), @"mvc.1.0.view", @"/Views/Investigation/ViewInvestigationEntry.cshtml")]
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
#line 1 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa7e767ce4b3e8389e98274a16805d7e42ef075d", @"/Views/Investigation/ViewInvestigationEntry.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ab5a5949b63007e87413bab4c69896099f52b9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Investigation_ViewInvestigationEntry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvestigationClass>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
  
    ViewData["Title"] = "Investigation Entry";

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

                <hr />

                <ul class=""list-group"">
                    <li class=""list-group-item""><span class=""font-weight-bold"">Investigation Description      - </span> ");
#nullable restore
#line 45 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                                   Write(Model.InvestigationDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Investigation Date      - </span> ");
#nullable restore
#line 46 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                            Write(Model.InvestigationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Investigator First Name  - </span> ");
#nullable restore
#line 47 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                             Write(Model.InvestigatorFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Investigator Last Name    - </span> ");
#nullable restore
#line 48 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                              Write(Model.InvestigatorLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Investigator Email      - </span> ");
#nullable restore
#line 49 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                            Write(Model.InvestigatorEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    <li class=\"list-group-item\"><span class=\"font-weight-bold\">Investigator Mobile   - </span> ");
#nullable restore
#line 50 "C:\Users\neilb\Desktop\Neil\Web Final\Web2\NEMESYS\Views\Investigation\ViewInvestigationEntry.cshtml"
                                                                                                          Write(Model.InvestigatorMobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                    \r\n                </ul>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvestigationClass> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
