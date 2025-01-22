using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace ASP_NET_05._HTML_Helpers.HtmlHelpers;

public static class HtmlListHelper
{
    public static HtmlString ListFor(
                            this IHtmlHelper helper,
                            IEnumerable<object> items,
                            string listTag = "ul",
                            string color="black",
                            string fontSize="16")
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<{listTag} " +
            $"style='color: {color};" +
            $"font-size:{fontSize}px'>");
        foreach(var item in items)
        {
            sb.AppendLine($"<li>{item}</li>");
        }
        sb.AppendLine($"</{listTag}>");

        return new HtmlString(sb.ToString());
    }
}
