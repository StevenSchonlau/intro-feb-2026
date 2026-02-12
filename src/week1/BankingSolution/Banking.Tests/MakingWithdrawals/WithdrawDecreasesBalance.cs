using Banking.Domain;

namespace Banking.Tests.MakingWithdrawals;

public class WithdrawDecreasesBalance
{
    [Fact]
    public void Example()
    {
        var account = new Account();


        var openingBalance = account.GetBalance();
        var amountToWithdraw = 123.23M;

        // When I deposit 123.23
        account.Withdraw(amountToWithdraw);


        // Then the balance of that account should increase by that amount
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}