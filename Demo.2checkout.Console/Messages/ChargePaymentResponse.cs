using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo._2checkout.Console.Messages
{
    public class ChargePaymentResponse : ResponseBase {
        public bool Error { set; get; }

        public string Message { set; get; }
    }
}
}
