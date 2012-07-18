using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace Saimoe.HtmlHelperExtensions
{
    public static class ModelMetadataExtensions
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.SetInnerText(ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData).Description);
            tagBuilder.MergeAttribute("data-description-for", ExpressionHelper.GetExpressionText(expression));
            tagBuilder.AddCssClass("description");
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}