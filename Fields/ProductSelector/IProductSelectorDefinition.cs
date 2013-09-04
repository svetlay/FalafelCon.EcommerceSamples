using System;
using System.Linq;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;

namespace Telerik.EcommerceSamples.Fields.ProductSelector
{
    public interface IProductSelectorDefinition : IFieldControlDefinition
    {
        /// <summary>
        /// Gets or sets the dynamic module type.
        /// </summary>
        /// <value>The dynamic module type.</value>
        string DynamicModuleType { get; set; }
    }
}