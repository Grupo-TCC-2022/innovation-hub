#pragma checksum "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c4cfca92680f9b5b6d04ca6ba95158fa0944249"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Wendel\Desktop\innovation-hub\Views\_ViewImports.cshtml"
using innovation_hub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Wendel\Desktop\innovation-hub\Views\_ViewImports.cshtml"
using innovation_hub.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c4cfca92680f9b5b6d04ca6ba95158fa0944249", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc7835f3c5c4e4d32cccb53bf2ab5aaec87a9232", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<innovation_hub.Models.Proposal>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Minhas propostas</h4>\r\n");
#nullable restore
#line 8 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
 foreach (Proposal proposal in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card feed-item mt-3\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 12 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
                              Write(proposal.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 13 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
             foreach (var item in proposal.Categories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h6 class=\"card-subtitle mb-2 text-muted\">");
#nullable restore
#line 15 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
                                                     Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 16 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"card-text\">");
#nullable restore
#line 17 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
                            Write(proposal.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <h6 href=\"#\" class=\"card-link\">Votos: ");
#nullable restore
#line 18 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
                                             Write(proposal.Votes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 21 "C:\Users\Wendel\Desktop\innovation-hub\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<innovation_hub.Models.Proposal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
