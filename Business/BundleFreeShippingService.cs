using System;
using System.Linq;
using Telerik.Sitefinity.Ecommerce.Orders.Model;
using Telerik.Sitefinity.Ecommerce.Shipping.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Ecommerce.BusinessServices.Shipping.Implementations;
using Telerik.Sitefinity.Modules.Ecommerce.Orders.Web.UI.CheckoutViews;

namespace FalafelCon.EcommerceSamples.Business
{
    public class BundleFreeShippingService : EcommerceShippingMethodService
    {
        public override IQueryable<IShippingResponse> GetApplicableShippingMethods(CheckoutState checkoutState, CartOrder cartOrder)
        {
            var allApplicableShippingMethods = base.GetApplicableShippingMethods(checkoutState, cartOrder);

            bool upSellCriteriaMet = DataExtensions.GetValue<bool>(cartOrder, "UpsellCriteriaMet");
            if (!upSellCriteriaMet)
            {
                return allApplicableShippingMethods.Where(sr => sr.ServiceName != "Free Shipping");
            }

            return allApplicableShippingMethods;
        }
    }
}