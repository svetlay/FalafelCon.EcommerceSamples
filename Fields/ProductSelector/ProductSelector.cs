using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.EcommerceSamples.Fields.ProductSelector;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;

namespace FalafelCon.EcommerceSamples.Fields.ProductSelector
{
    /// <summary>
    /// A simple field control used to select a dynamic items.
    /// Use the path to this class when you add the field control in Sitefinity Module Builder
    /// Telerik.EcommerceSamples.Fields.ProductSelector.ProductSelector
    /// </summary>
    [FieldDefinitionElement(typeof(FalafelCon.EcommerceSamples.Fields.ProductSelector.ProductSelectorElement))]
    public class ProductSelector : FieldControl
    {
        
        #region Properties
        
        protected override WebControl TitleControl
        {
            get
            {
                return this.TitleLabel;
            }
        }
        
        protected override WebControl DescriptionControl
        {
            get
            {
                return this.DescriptionLabel;
            }
        }
        
        protected override WebControl ExampleControl
        {
            get
            {
                return this.ExampleLabel;
            }
        }
        
        protected override string LayoutTemplateName
        {
            get
            {
                return String.Empty;
            }
        }
        
        public override string LayoutTemplatePath
        {
            get
            {
                return ProductSelector.layoutTemplate;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        
        /// <summary>
        /// Gets the title label.
        /// </summary>
        /// <value>The title label.</value>
        protected internal virtual Label TitleLabel
        {
            get
            {
                SitefinityLabel titleLabel = this.Container.GetControl<SitefinityLabel>("titleLabel", true);
                return titleLabel;
            }
        }
        
        /// <summary>
        /// Gets the description label.
        /// </summary>
        /// <value>The description label.</value>
        protected internal virtual Label DescriptionLabel
        {
            get
            {
                SitefinityLabel descriptionLabel = this.Container.GetControl<SitefinityLabel>("descriptionLabel", true);
                return descriptionLabel;
            }
        }
        
        /// <summary>
        /// Gets the example label.
        /// </summary>
        /// <value>The example label.</value>
        protected internal virtual Label ExampleLabel
        {
            get
            {
                SitefinityLabel exampleLabel = this.Container.GetControl<SitefinityLabel>("exampleLabel", true);
                return exampleLabel;
            }
        }
        
        /// <summary>
        /// Get a reference to the content selector
        /// </summary>
        protected virtual FlatSelector ItemsSelector
        {
            get
            {
                return this.Container.GetControl<FlatSelector>("itemsSelector", true);
            }
        }
        
        /// <summary>
        /// Get a reference to the selected items list
        /// </summary>
        protected virtual HtmlGenericControl SelectedItemsList
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectedItemsList", true);
            }
        }
        
        /// <summary>
        /// Get a reference to the selector wrapper
        /// </summary>
        protected virtual HtmlGenericControl SelectorWrapper
        {
            get
            {
                return this.Container.GetControl<HtmlGenericControl>("selectorWrapper", true);
            }
        }
        
        /// <summary>
        /// The LinkButton for "Done"
        /// </summary>
        protected virtual LinkButton DoneButton
        {
            get
            {
                return this.Container.GetControl<LinkButton>("doneButton", true);
            }
        }
        
        /// <summary>
        /// The LinkButton for "Cancel"
        /// </summary>
        protected virtual LinkButton CancelButton
        {
            get
            {
                return this.Container.GetControl<LinkButton>("cancelButton", true);
            }
        }
        
        /// <summary>
        /// The button area control
        /// </summary>
        protected virtual Control ButtonArea
        {
            get
            {
                return this.Container.GetControl<Control>("buttonAreaPanel", false);
            }
        }
        
        /// <summary>
        /// Get a reference to the link that opens the selector
        /// </summary>
        protected virtual HyperLink SelectButton
        {
            get
            {
                return this.Container.GetControl<HyperLink>("selectButton", true);
            }
        }
        
        /// <summary>
        /// Get or set the dynamic module type 
        /// </summary>
        public string DynamicModuleType
        {
            get
            {
                return this.dynamicModuleType;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.dynamicModuleType = value;
                }
            }
        }

        #endregion
        
        #region Overridden Methods
        
        protected override void InitializeControls(GenericContainer container)
        {
            this.TitleLabel.Text = this.Title;
            this.DescriptionLabel.Text = this.Description;
            this.ExampleLabel.Text = this.Example;
            this.ItemsSelector.ServiceUrl = ProductSelector.DynamicModulesDataServicePath;
            this.ItemsSelector.ItemType = this.DynamicModuleType;
        }
        
        public override void Configure(IFieldDefinition definition)
        {
            base.Configure(definition);
            
            IProductSelectorDefinition fieldDefinition = definition as IProductSelectorDefinition;
            
            if (fieldDefinition != null)
            {
                if (!string.IsNullOrEmpty(fieldDefinition.DynamicModuleType))
                {
                    this.DynamicModuleType = fieldDefinition.DynamicModuleType;
                }
            }
        }
        
        protected override ScriptRef GetRequiredCoreScripts()
        {
            return ScriptRef.JQuery |
                   ScriptRef.JQueryUI |
                   ScriptRef.KendoAll;
        }
        
        #endregion
        
        #region IScriptControl Members

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>(base.GetScriptReferences());
            
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Web.UI.Scripts.IRequiresProvider.js", "Telerik.Sitefinity"));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Web.UI.Fields.Scripts.ILocalizableFieldControl.js", "Telerik.Sitefinity"));
            scripts.Add(new ScriptReference(ProductSelector.scriptReference, typeof(ProductSelector).Assembly.FullName));
            return scripts;
        }
        
        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var lastDescriptor = (ScriptControlDescriptor)descriptors.Last();
            lastDescriptor.AddElementProperty("selectButton", this.SelectButton.ClientID);
            lastDescriptor.AddComponentProperty("itemsSelector", this.ItemsSelector.ClientID);
            lastDescriptor.AddElementProperty("selectorWrapper", this.SelectorWrapper.ClientID);
            lastDescriptor.AddElementProperty("selectedItemsList", this.SelectedItemsList.ClientID);
            lastDescriptor.AddElementProperty("doneButton", this.DoneButton.ClientID);
            lastDescriptor.AddElementProperty("cancelButton", this.CancelButton.ClientID);
            lastDescriptor.AddProperty("dynamicModulesDataServicePath", RouteHelper.ResolveUrl(ProductSelector.DynamicModulesDataServicePath, UrlResolveOptions.Rooted));
            lastDescriptor.AddProperty("dynamicModuleType", this.DynamicModuleType);
            
            return descriptors;
        }
        
        #endregion
        
        #region Private Fields

        private const string DynamicModulesDataServicePath = "~/Sitefinity/Services/Ecommerce/Catalog/ProductService.svc/";
        
        private static readonly string scriptReference = typeof(ProductSelector).Namespace + ".ProductSelector.js";
        private static readonly string layoutTemplate = "~/TelerikEcommerceSamples/" + typeof(ProductSelector).Namespace + ".ProductSelector.ascx";
        
        private string dynamicModuleType = "Telerik.Sitefinity.Ecommerce.Catalog.Model.Product";

        #endregion

    }
}