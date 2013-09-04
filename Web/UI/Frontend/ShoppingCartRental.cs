using System;
using System.Linq;
using Telerik.Sitefinity.Ecommerce.Catalog.Model;
using Telerik.Sitefinity.Ecommerce.Orders.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Ecommerce.Orders.Web.UI;
using Telerik.Web.UI;

namespace FalafelCon.EcommerceSamples.Web.UI.Frontend
{
    public class ShoppingCartRental : ShoppingCart
    {
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.InitializeControls(container);
            ShoppingCartGrid.ItemDataBound += ShoppingCartGrid_RentalsItemDataBound;
        }

        private void ShoppingCartGrid_RentalsItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                var cartDetail = (CartDetail)e.Item.DataItem;
                RadDatePicker startDatePicker = (RadDatePicker)e.Item.FindControl("startDatePicker");
                RadDatePicker endDatePicker = (RadDatePicker)e.Item.FindControl("endDatePicker");

                //Hide the date pickers if it's not a notebook
                ProductType notebook = CatalogManager.GetProductTypes().Where(pt => pt.Title == "Notebook").SingleOrDefault();
                Product product = CatalogManager.GetProduct(cartDetail.ProductId);

                if (product.ClrType != notebook.ClrType)
                {
                    startDatePicker.Visible = false;
                    endDatePicker.Visible = false;
                }
                else
                {
                    DateTime startDate;
                    DateTime endDate;
                    if (DateTime.TryParse(DataExtensions.GetValue<string>(cartDetail, "startDate"), out startDate))
                    {
                        startDatePicker.SelectedDate = startDate;
                    }

                    if (DateTime.TryParse(DataExtensions.GetValue<string>(cartDetail, "endDate"), out endDate))
                    {
                        endDatePicker.SelectedDate = startDate;
                    }
                }
            }
        }
    }
}