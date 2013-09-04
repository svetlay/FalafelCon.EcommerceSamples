using System;
using System.Linq;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;

namespace FalafelCon.EcommerceSamples.Web.UI.Frontend
{
    public class RentalDatePickerControl : SimpleView
    {
        
        #region Control References
        
        public RadDatePicker StartDatePicker
        {
            get
            {
                return this.Container.GetControl<RadDatePicker>("StartDate", true);
            }
        }
        
        public RadDatePicker EndDatePicker
        {
            get
            {
                return this.Container.GetControl<RadDatePicker>("EndDate", true);
            }
        }

        #endregion

        #region Public Properties
        
        public DateTime StartDate
        {
            get
            {
                return StartDatePicker.SelectedDate.Value;
            }
        }
        
        public DateTime EndDate
        {
            get
            {
                return EndDatePicker.SelectedDate.Value;
            }
        }

        #endregion

        #region Overriden Methods
        
        /// <summary>
        /// Gets or sets the path of the external template to be used by the control.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    base.LayoutTemplatePath = RentalDatePickerControl.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        
        protected override void InitializeControls(GenericContainer container)
        {
            StartDatePicker.SelectedDate = DateTime.Now;
            EndDatePicker.SelectedDate = DateTime.Now.AddDays(7);
        }

        #endregion

        #region Private Properties
        
        private readonly static string layoutTemplatePath = "~/TelerikEcommerceSamples/Telerik.EcommerceSamples.Web.UI.Frontend.Resources.RentalDatePickerControl.ascx";
        
        #endregion

    }
}