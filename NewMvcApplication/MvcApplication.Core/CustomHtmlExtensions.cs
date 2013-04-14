using NewMvcApplication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc.Html
{

    public static class CustomHtmlExtensions
    {
        public static MvcHtmlString EditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, EditorTemplate editorTemplate)
        {
            return html.EditorFor(expression, editorTemplate.ToString());
        }
    }
    
}
