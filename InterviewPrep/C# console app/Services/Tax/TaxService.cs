using Backend.Helpers.Constants;
using Backend.Services.Tax.Interfaces;

namespace Backend.Services.Tax
{
    public class TaxService : ITaxService
    {
        private const decimal TWO_THOUSAND = 2000M;

        public decimal CalculateIncomeTax(decimal salary)
        {
            var taxAmount = (salary - TaxConstants.TaxFreeAmount) * TaxConstants.IncomeTaxPercent;            

            return taxAmount;
        }

        public decimal CalculateSocialContributionTax(decimal salary)
        {
            decimal taxAmount = TaxConstants.DefaultZeroTaxAmount;

            if (salary >= TaxConstants.MaximumTaxAmount)
            {
                taxAmount += TWO_THOUSAND * TaxConstants.ContributionTaxPercent;
            }
            else if (salary > TaxConstants.TaxFreeAmount)
            {
                taxAmount += (taxAmount - TaxConstants.TaxFreeAmount) * TaxConstants.ContributionTaxPercent;
            }

            return taxAmount;
        }
    }
}
