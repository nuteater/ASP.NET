﻿namespace NewName.NewAbpZeroTemplate.MultiTenancy.Payments.Paypal
{
    public class PayPalCaptureOrderRequestInput
    {
        public string OrderId { get; set; }

        public PayPalCaptureOrderRequestInput(string orderId)
        {
            OrderId = orderId;
        }
    }
}