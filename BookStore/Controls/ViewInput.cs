using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Controls
{
    public class ViewInput : WebControl
    {
        public string Namespace
        {
            get;
            set;
        } = "BookStore.Models";

        public string ModelName
        {
            get;
            set;
        } = "Order";

        public string PropertyName
        {
            get;
            set;
        }



        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, PropertyName.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, PropertyName.ToLower());

            var modelType = Type.GetType($"{Namespace}.{ModelName}");
            var propInfo = modelType.GetProperty(PropertyName);
            var reqAttribute = propInfo.GetCustomAttribute<RequiredAttribute>(false);

            AddDataValidateAttribute(reqAttribute, output);
            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        void AddDataValidateAttribute(RequiredAttribute attribute, HtmlTextWriter output)
        {
            if (attribute == null) return;
            output.AddAttribute("data-val", "true");
            output.AddAttribute("data-val-required", attribute.ErrorMessage);
        }
    }
}
