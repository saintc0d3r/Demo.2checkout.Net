using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TwoCheckout;

namespace Demo._2checkout.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoCheckoutConfig.SellerID = "901288242";
            TwoCheckoutConfig.PrivateKey = "80D02EA2-4847-4AC0-9E11-77B50CDFBB97";
            TwoCheckoutConfig.Sandbox = true;   //<-- Set Mode to use your 2Checkout sandbox account
            System.Console.Write("Enter cc token:");
            var token = System.Console.ReadLine();;

            try
            {
                var Billing = new AuthBillingAddress();
                Billing.addrLine1 = "123 test st";
                Billing.city = "Columbus";
                Billing.zipCode = "43123";
                Billing.state = "OH";
                Billing.country = "USA";
                Billing.name = "Testing Tester";
                Billing.email = "example@2co.com";
                Billing.phoneNumber = "5555555555";

                var Customer = new ChargeAuthorizeServiceOptions();
                Customer.total = (decimal)1.00;
                Customer.currency = "USD";
                Customer.merchantOrderId = "123";
                Customer.billingAddr = Billing;
                Customer.token = token;
                Customer.lineItems = new List<AuthLineitem>();

                Customer.lineItems.Add(new AuthLineitem {
                    price = 1,
                    name = "Baygon",
                    productId = "5567",
                    type = "product", // TODO: this should be passed in from outside. Possible values: ‘product’, ‘shipping’, ‘tax’ or ‘coupon’
                    quantity = 1      // TODO: this should be passed in from outside. Possible values: 1-999                    
                });

                var Charge = new ChargeService();

                var result = Charge.Authorize(Customer);
                System.Console.Write("[INFO] - Charging is success. Response code: "+result.responseCode+", message: "+result.responseMsg);
            }
            catch (TwoCheckoutException e)
            {
                System.Console.Write("[ERROR] - Charing is failed. Exception: "+e.Message);
            }            
        }

        //private static ChargePaymentResponse ChargePayment(ChargePaymentRequest request)
        //{

        //}
    }
}
