using Telerik.EcommerceSamples.Fields.ProductSelector;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace FalafelCon.EcommerceSamples.Fields.ProductSelector
{
    /// <summary>
    /// A control definition for the simple image field
    /// </summary>
    public class ProductSelectorDefinition : FieldControlDefinition, IProductSelectorDefinition
    {
        
        #region Constuctors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSelectorDefinition"/> class.
        /// </summary>
        public ProductSelectorDefinition() : base()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSelectorDefinition"/> class.
        /// </summary>
        /// <param name="element">The configuration element used to persist the control definition.</param>
        public ProductSelectorDefinition(ConfigElement element) : base(element)
        {
        }

        #endregion
        
        #region IProductSelectorDefinition members
        
        public string DynamicModuleType
        {
            get
            {
                return this.ResolveProperty("DynamicModuleType", this.dynamicModuleType);
            }
            set
            {
                this.dynamicModuleType = value;
            }
        }
        
        #endregion
        
        #region Private members
        
        private string dynamicModuleType;

        #endregion

    }
}