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
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxWithPlaceholderFor(expression, null, null);
        }
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return htmlHelper.TextBoxWithPlaceholderFor(expression, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.TextBoxWithPlaceholderFor(expression, null, htmlAttributes);
        }
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeHolder)
        {
            return htmlHelper.TextBoxWithPlaceholderFor(expression, placeHolder, null);
        }
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeHolder, object htmlAttributes)
        {
            return htmlHelper.TextBoxWithPlaceholderFor(expression, placeHolder, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        public static MvcHtmlString TextBoxWithPlaceholderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string placeHolder, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (placeHolder == null)
            {
                placeHolder = modelMetadata.Description;
                if (string.IsNullOrEmpty(placeHolder))
                {
                    placeHolder = modelMetadata.DisplayName;
                }
            }
            if (htmlAttributes == null)
            {
                htmlAttributes = new Dictionary<string, object>();
            }
            htmlAttributes["placeholder"] = placeHolder;
            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }
    }
}