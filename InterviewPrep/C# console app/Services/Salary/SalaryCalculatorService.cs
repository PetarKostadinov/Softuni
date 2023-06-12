using Backend.Helpers.Constants;
using Backend.Services.Salary.Interfaces;
using Backend.Services.Tax.Interfaces;

namespace Backend.Services.Salary
{
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        private const string IMAGINARIA_CURRENCY_SYMBOL = "IDR";

        private readonly ITaxService taxService;

        public SalaryCalculatorService(ITaxService taxService)
        {
            this.taxService = taxService;
        }

        public string CalculateSalary(string input)
        {
            var isValidSalary = decimal.TryParse(input, out var salary);

            if (!isValidSalary) return ErrorMessages.InvalidSalaryErrorMessage;            

            var totalTaxes = CalculateTotalTaxes(salary);

            var salaryAfterTaxes = salary - totalTaxes;

            return $"{salaryAfterTaxes} {IMAGINARIA_CURRENCY_SYMBOL}";
        }

        private decimal CalculateTotalTaxes(decimal salary)
        {
            var totalTaxes = TaxConstants.DefaultZeroTaxAmount;

            if (salary > TaxConstants.TaxFreeAmount)
            {
                totalTaxes += this.taxService.CalculateIncomeTax(salary);
                totalTaxes += this.taxService.CalculateSocialContributionTax(salary);
            }

            return totalTaxes;
        }
    }
}
