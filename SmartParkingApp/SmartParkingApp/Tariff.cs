namespace SmartParkingApp
{
    class Tariff
    {
        public int Minutes { get; set; }
        public decimal Rate { get; set; }

        public Tariff(decimal rate, int minutes)
        {
            Rate = rate;
            Minutes = minutes;
        }
    }
}
