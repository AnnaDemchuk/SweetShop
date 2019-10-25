using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebUIAu.Helpers
{
    public static class EnumEditorHtmlHelper
    {
        
        public static IEnumerable<SelectListItem> createSelectList(Type enumType)
        {
            return (from object item in Enum.GetValues(enumType)
                    let fi = enumType.GetField(item.ToString())
                    let attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault()
                    let title = attribute == null ? item.ToString() : ((DescriptionAttribute)attribute).Description
                    select new SelectListItem
                    {
                        Value = item.ToString(),
                        Text = title,
                    }).ToList();
        }
        
    }
}