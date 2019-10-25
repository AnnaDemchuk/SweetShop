using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUIAu.Models;

namespace WebUIAu.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<ul class=\"pagination\">");
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                if (pagingInfo.TotalPages > 20 && (i > 11 && i < pagingInfo.TotalPages - 10))
                    continue;

                else if (pagingInfo.TotalPages > 20 && i == 11)
                {
                    result.Append("<li>");
                    TagBuilder tag1 = new TagBuilder("a"); // Создание дескриптора <a>
                    tag1.MergeAttribute("href", "#");
                    tag1.AddCssClass("mypaging");
                    tag1.InnerHtml = "...";


                    result.Append(tag1.ToString());
                    result.Append("</li>");
                }

                if (i == pagingInfo.CurrentPage) result.Append("<li class=\"active\">");
                else result.Append("<li>");
                TagBuilder tag = new TagBuilder("a"); // Создание дескриптора <a>
                tag.MergeAttribute("href", "#");
                tag.AddCssClass("mypaging");
                tag.InnerHtml = i.ToString();


                result.Append(tag.ToString());
                result.Append("</li>");

            }
            result.Append("</ul>");
            return MvcHtmlString.Create(result.ToString());
        }

    }
}