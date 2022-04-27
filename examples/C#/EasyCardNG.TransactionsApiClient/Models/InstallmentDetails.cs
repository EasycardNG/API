using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Integration.Models
{
    /// <summary>
    /// Installment payments details
    /// </summary>
    public class InstallmentDetails
    {
        /// <summary>
        /// Number Of Installments
        /// </summary>
        [Range(1, 100)]
        [Required(AllowEmptyStrings = false)]
        public int NumberOfPayments { get; set; }

        /// <summary>
        /// Initial installment payment
        /// </summary>
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false)]
        public decimal InitialPaymentAmount { get; set; }

        /// <summary>
        /// TotalAmount = InitialPaymentAmount + (NumberOfInstallments - 1) * InstallmentPaymentAmount
        /// </summary>
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Amount of each additional payments
        /// </summary>
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Required(AllowEmptyStrings = false)]
        public decimal InstallmentPaymentAmount { get; set; }
    }
}
