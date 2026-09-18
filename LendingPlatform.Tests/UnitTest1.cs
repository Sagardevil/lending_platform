using LendingPlatform.API.Models;
using LendingPlatform.API.Services;
using Xunit;

namespace LendingPlatform.Tests;

public class LendingServiceTests
{
    private readonly ILendingService _service;

    public LendingServiceTests()
    {
        _service = new LendingService();
    }

    [Fact]
    public void EvaluateApplication_LoanLessThan100k_ShouldDecline()
    {
        var req = new ApplicationRequest { LoanAmount = 99999, AssetValue = 200000, CreditScore = 900 };
        var res = _service.EvaluateApplication(req);

        Assert.False(res.IsSuccessful);
        Assert.Contains("between £100,000 and £1,500,000", res.DecisionReason);
    }

    [Fact]
    public void EvaluateApplication_HighValueLoanValidCriteria_ShouldApprove()
    {
        var req = new ApplicationRequest { LoanAmount = 1000000, AssetValue = 2000000, CreditScore = 950 };
        var res = _service.EvaluateApplication(req);

        Assert.True(res.IsSuccessful);
    }

    [Fact]
    public void EvaluateApplication_LowValueLoanLtv85Credit799_ShouldDecline()
    {
        // Ltv = 85%, requires credit score >= 900
        var req = new ApplicationRequest { LoanAmount = 170000, AssetValue = 200000, CreditScore = 799 };
        var res = _service.EvaluateApplication(req);

        Assert.False(res.IsSuccessful);
    }
}