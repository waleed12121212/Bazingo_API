﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Application.DTO_s.Payment
{
    public class InitiatePaymentDto
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } // CreditCard, COD, PayPal
    }
}
