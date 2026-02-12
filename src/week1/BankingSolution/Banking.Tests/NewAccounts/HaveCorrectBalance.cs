


using Banking.Domain;

namespace Banking.Tests.NewAccounts;

public class HaveCorrectBalance
{
    [Fact]
    public void BalanceIsCorrect()
    {
        //WTCYWYH - Write the code you wish you had. -> leads to cohesion
        var myAccount = new Account();
        decimal openingBalance = myAccount.GetBalance();

        Assert.Equal(5000M, openingBalance); //M - decimal - assumes int32/float double w/o this
    }
}
