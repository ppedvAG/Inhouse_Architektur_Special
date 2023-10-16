using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;

namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_zero_as_balance()
        {
            var ba = new BankAccount();

            //Assert.Equal(0, ba.Balance);
            ba.Balance.Should().Be(0);
        }

        [Fact]
        public void Deposit_should_add_to_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            ba.Deposit(5m);

            ba.Balance.Should().Be(10);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void Deposit_negative_or_zero_as_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Action action = () => ba.Deposit(value);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Withdraw_should_substract_from_balance()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            ba.Withdraw(5m);

            ba.Balance.Should().Be(15);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void Withdraw_negative_or_zero_as_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Action action = () => ba.Withdraw(value);

            action.Should().Throw<ArgumentException>();

        }

        [Fact]
        public void Withdraw_more_than_balance_throw_InvalivOpEx()
        {
            var ba = new BankAccount();
            ba.Deposit(20);

            Action action = () => ba.Withdraw(21);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Withdraw_to_zero_balance()
        {
            var ba = new BankAccount();
            ba.Deposit(21);

            ba.Withdraw(21);

            ba.Balance.Should().Be(0);
        }



        [Fact]
        public void IsNowWeekend_Tests()
        {
            var ba = new BankAccount();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,16);
                ba.IsNowWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,17);
                ba.IsNowWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,18);
                ba.IsNowWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,19);
                ba.IsNowWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,20);
                ba.IsNowWeekend().Should().BeFalse();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,21);
                ba.IsNowWeekend().Should().BeTrue();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023,10,22);
                ba.IsNowWeekend().Should().BeTrue();
            }
        }


        [Fact]
        public void TestIsFileFullOfBeer()
        {
            using (ShimsContext.Create())
            {
                // Fälschen der File.ReadAllText-Methode
                System.IO.Fakes.ShimFile.ReadAllTextString = (path) =>
                {
                    // Hier können Sie den simulierten Dateiinhalt festlegen
                    return "🍺";
                };

                // Ihre Methode testen
                var myClass = new BankAccount(); // Stellen Sie sicher, dass Sie Ihre Klasse initialisieren
                bool result = myClass.IsFileFullOfBeer();

                // Überprüfen, ob Ihre Methode das erwartete Ergebnis zurückgibt
                result.Should().BeTrue();
            }
        }
    }
}