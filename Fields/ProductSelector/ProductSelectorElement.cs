using System;
using System.Configuration;
using FalafelCon.EcommerceSamples.Fields.ProductSelector;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace FalafelCon.EcommerceSamples.Fields.ProductSelector
{
    /// <summary>
    /// A configuration element used to persist the properties of <see cref="ProductSelectorDefinition"/>
    /// </summary>
    public class ProductSelectorElement : FieldControlDefinitionElement, Telerik.EcommerceSamples.Fields.ProductSelector.IProductSelectorDefinition
    {
        
        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSelectorElement"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ProductSelectorElement(ConfigElement parent) : base(parent)
        {
        }

        #endregion
        
        #region FieldControlDefinitionElement Members
        
        /// <summary>
        /// Gets an instance of the <see cref="ProductSelectorDefinition"/> class.
        /// </summary>
        public override DefinitionBase GetDefinition()
        {
            return new ProductSelectorDefinition(this);
        }
        
        #endregion
        
        #region IFieldDefinition members
        
        public override Type DefaultFieldType
        {
            get
            {
                return typeof(FalafelCon.EcommerceSamples.Fields.ProductSelector.ProductSelector);
            }
        }
        
        #endregion
        
        #region IProductSelectorDefinition Members
        
        /// <summary>
        /// Gets or sets the dynamic module type
        /// </summary>
        [ConfigurationProperty("DynamicModuleType")]
        public string DynamicModuleType
        {
            get
            {
                return (string)this["DynamicModuleType"];
            }
            set
            {
                this["DynamicModuleType"] = value;
            }
        }

        #endregion

    }
}