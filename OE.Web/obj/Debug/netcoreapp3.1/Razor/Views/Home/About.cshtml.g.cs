#pragma checksum "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "364c10a596afcad3467f54efef44ca986272208b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#line 1 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\_ViewImports.cshtml"
using OE.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\_ViewImports.cshtml"
using OE.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"364c10a596afcad3467f54efef44ca986272208b", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"694f2c441ff9a2d72ab5ec4218a271bd2a6b2fec", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OE.Web.Models.IndexAboutVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h2>test</h2>\r\n\r\n\r\n");
            WriteLiteral(@"

<div class=""container container-customized"">
    <ul class=""nav nav-tabs"">
        <li class=""active""><a data-toggle=""tab"" href=""#home""><b>About</b></a></li>
        <li><a data-toggle=""tab"" href=""#menu1""><b>Mission & Vision</b></a></li>
        <li><a data-toggle=""tab"" href=""#menu2""><b>Our Product</b></a></li>
        <li><a data-toggle=""tab"" href=""#menu3""><b>Our Team</b></a></li>
    </ul>

    <div class=""tab-content"">
        <div id=""home"" class=""tab-pane fade in active"">
");
            WriteLiteral("            ");
#nullable restore
#line 18 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\Home\About.cshtml"
       Write(await Html.PartialAsync("about/_aboutUs"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div id=\"menu1\" class=\"tab-pane fade\">           \r\n            ");
#nullable restore
#line 21 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\Home\About.cshtml"
       Write(await Html.PartialAsync("about/_missionAndVision"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div id=\"menu2\" class=\"tab-pane fade\">           \r\n            ");
#nullable restore
#line 24 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\Home\About.cshtml"
       Write(await Html.PartialAsync("about/_products"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div id=\"menu3\" class=\"tab-pane fade \" style=\"font-family:\'arial\';color: #34495E;\">          \r\n            ");
#nullable restore
#line 27 "F:\OurEduProjects\OurEdu_My Work\OE.Web\Views\Home\About.cshtml"
       Write(await Html.PartialAsync("about/_ourTeam", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OE.Web.Models.IndexAboutVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
