using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    public class PaymentResultViewModel
    {
        public string TransactionID { get; set; }

        public string InternalOrderID { get; set; }

        #region legacy callback parameters
        public string StateData { get; set; }
        public string CardOwner { get; set; }
        public string OwnerEmail { get; set; }
        public string Id { get; set; }
        public string OkNumber { get; set; }
        public string Code { get; set; }
        public string DealID { get; set; }
        public string BusinessName { get; set; }
        public string Terminal { get; set; }
        public string DealNumber { get; set; }
        public string CardNumber { get; set; }
        public string DealDate { get; set; }
        public string PayNumber { get; set; }
        public string FirstPay { get; set; }
        public string AddPay { get; set; }
        public string DealTypeOut { get; set; }
        public string DealType { get; set; }
        public string Currency { get; set; }
        public string CardNameID { get; set; }
        public string Manpik { get; set; }
        public string Mutag { get; set; }
        public string DealTypeID { get; set; }
        public string CurrencyID { get; set; }
        public string CardNameIDCode { get; set; }
        public string ManpikID { get; set; }
        public string MutagID { get; set; }
        public string Tz { get; set; }
        public string CardDate { get; set; }
        public string Token { get; set; }
        public string PhoneNumber { get; set; }
        public string EmvSoftVersion { get; set; }
        public string OriginalUID { get; set; }
        public string CompRetailerNum { get; set; }
        public string Total { get; set; }
        #endregion legacy callback parameters

        public string Payload { get; set; }
    }
}
