using System;
using System.Linq;
using FalafelCon.EcommerceSamples.Business;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.Ecommerce.BusinessServices.Shipping.Interfaces;

namespace FalafelCon.EcommerceSamples
{
    public static class Installer
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        static void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                ObjectFactory.Container.RegisterType<IEcommerceShippingMethodService, BundleFreeShippingService>(new ContainerControlledLifetimeManager());
            }
        }
    }
}
