using MVC_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_application.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DisplayPagination(this HtmlHelper html, PageInfo pageInfo, Func<int, string> link)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.PagesCount; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.InnerHtml = i.ToString();

                tag.AddCssClass("btn");

                if (i == pageInfo.CurrentNumber)
                {
                    tag.AddCssClass("btn-primary selected");
                }

                tag.MergeAttribute("href", link(i));
                tag.MergeAttribute("style", "display:block");

                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString DisplayButton(this HtmlHelper html, string inner, string link)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.InnerHtml = inner;
            tag.AddCssClass("btn btn-link");
            tag.MergeAttribute("href", link);
            tag.MergeAttribute("style", "display:block");
            return MvcHtmlString.Create(tag.ToString());
        }
    }
}