

namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal v)
        {
            if (v <= 0)
                throw new ArgumentException("Nicht 0 oder weniger");

            Balance += v;
        }

        public void Withdraw(decimal v)
        {
            if (v <= 0)
                throw new ArgumentException("Nicht 0 oder weniger");

            if (v > Balance)
                throw new InvalidOperationException("Zu viel Geld ist nicht da");

            Balance -= v;
        }


        public bool IsNowWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }


        public bool IsFileFullOfBeer()
        {
            return File.ReadAllText("ö:\\WichtigDatei.txt") == "🍺";
        }

    }
}
