using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Shoes_Store3.Models
{
    public static class PagHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagePag pagePag,
Func<int, string> pageUrl)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 1; i <= pagePag.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagePag.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                res.Append(tag.ToString());
            }
            return MvcHtmlString.Create(res.ToString());
        }
    }
}