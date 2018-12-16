using System;
using System.Text;
using GandivaTestProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;


namespace GandivaTestProject.Helpers
{
   
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper html,
            PageViewModel pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                
                tag.InnerHtml.Append(i.ToString());
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                var writer = new System.IO.StringWriter();
                tag.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result.Append(writer.ToString());
            }
            return new HtmlString(result.ToString());
        }

        //public static string GetString(IHtmlContent content)
        //{
        //    var writer = new System.IO.StringWriter();
        //    content.WriteTo(writer, HtmlEncoder.Default);
        //    return writer.ToString();
        //}
    }
}
