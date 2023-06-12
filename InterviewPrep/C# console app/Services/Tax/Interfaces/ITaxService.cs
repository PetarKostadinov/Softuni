namespace Backend.Services.Tax.Interfaces
{
    public interface ITaxService
    {
        decimal CalculateIncomeTax(decimal salary);

        decimal CalculateSocialContributionTax(decimal salary);
    }
}
