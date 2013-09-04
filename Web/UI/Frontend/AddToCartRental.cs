using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Ecommerce.Orders.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Ecommerce.Orders;
using Telerik.Sitefinity.Modules.Ecommerce.Orders.Web.UI;

namespace FalafelCon.EcommerceSamples.Web.UI.Frontend
{
    public class AddToCartRental : AddToCartWidget
    {
        
        #region Properties
        
        protected OrdersManager OrdersManager
        {
            get
            {
                if (this.ordersManager == null)
                    this.ordersManager = OrdersManager.GetManager(this.OrdersProviderName);
                return this.ordersManager;
            }
        }

        #endregion

        #region Overridden Methods
        
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.InitializeControls(container);
            
            AddToCartButton.Command += new CommandEventHandler(AddToCartRentalButton_Command);
        }

        #endregion

        #region Event Handlers
        
        private void AddToCartRentalButton_Command(object sender, CommandEventArgs e)
        {
            var cartDetails = OrdersManager.GetCartDetails().Where(cd => cd.ProductId == ProductId);

            Tuple<DateTime, DateTime> selectedRentalDates = GetRentalDateTimes();
            
            foreach (CartDetail cartDetail in cartDetails)
            {
                DataExtensions.SetValue((IDynamicFieldsContainer)cartDetail, "startDate", selectedRentalDates.Item1);
                DataExtensions.SetValue((IDynamicFieldsContainer)cartDetail, "endDate", selectedRentalDates.Item2);
                
                TimeSpan? timeSpan = (selectedRentalDates.Item2 - selectedRentalDates.Item1);
                var days = timeSpan.Value.Days;
                
                if (days < 7)
                {
                    //cartDetail.Variations.
                }
                
                if (days > 0)
                {
                    cartDetail.Quantity = days;
                }
            }
            
            OrdersManager.SaveChanges();
        }
         
        #endregion

        #region Utility Methods
        
        private Tuple<DateTime, DateTime> GetRentalDateTimes()
        {
            Control parent = this.Parent;
            
            foreach (Control control in parent.Controls)
            {
                if (control.GetType().Name == "RentalDatePickerControl")
                {
                    RentalDatePickerControl productRentalDatePickerControl = (RentalDatePickerControl)control;
                    
                    return new Tuple<DateTime, DateTime>(productRentalDatePickerControl.StartDate, productRentalDatePickerControl.EndDate);
                }
            }
            return null;
        }

        #endregion

        #region Private Fields
        
        private OrdersManager ordersManager;
        
        #endregion 

    }
}