namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_zero_as_balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            ba.Deposit(5m);

            Assert.Equal(10, ba.Balance);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void Deposit_negative_or_zero_as_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(value));
        }

        [Fact]
        public void Withdraw_should_substract_from_balance()
        {
            var ba = new BankAccount();
            ba.Deposit(20m);

            ba.Withdraw(5m);

            Assert.Equal(15, ba.Balance);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void Withdraw_negative_or_zero_as_value_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(value));
        }

        [Fact]
        public void Withdraw_more_than_balance_throw_InvalivOpEx()
        {
            var ba = new BankAccount();
            ba.Deposit(20);


            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(21));
        }
    }
}