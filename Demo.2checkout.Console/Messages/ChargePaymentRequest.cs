
namespace Demo._2checkout.Console.Messages
{
    public class ChargePaymentRequest
    {
        public ChargePaymentRequest() { ContactDetails = new ContactDetails(); }

        /// <summary>
        /// Name of the payment account's owner
        /// </summary>
        public string AccountOwnerName { set; get; }

        // TODO: Add other account owner's detail info (e.g. billing address lines, contact detail fields)

        public ContactDetails ContactDetails { private set; get; }

        public IEnumerable<Product> Products { set; get; }

        public decimal Total { set; get; }

        /// <summary>
        /// Payment account's keys (e.g. payment gateway's token, Credit card number, ccv, expiry, paypal's credentials, etc)
        /// </summary>
        public string[] Keys { set; get; }
    }
}
