using System;
using System.Collections.Generic;

namespace Test.Web.Enums
{
    public enum PaymentType
    {
        Price,
        MonthlyRate
    }

    public static class PaymentTypeExtension
    {
        private static IDictionary<PaymentType, string> PaymentTypeId = new Dictionary<PaymentType, string>()
        {
            {PaymentType.Price, "searchForPrice"},
            {PaymentType.MonthlyRate, "searchForMonthlyRate"}
        };

        public static string GetId(this PaymentType radioButton)
        {
            if (!PaymentTypeId.ContainsKey(radioButton))
            {
                throw new NotSupportedException($"Id for {radioButton} radio button is not defined");
            }

            return PaymentTypeId[radioButton];
        }
    }
}