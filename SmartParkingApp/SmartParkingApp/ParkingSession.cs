using System;

namespace ParkingApp
{
    class ParkingSession
    {
        private static Random rand = new Random();

        // Date and time of arriving at the parking
        public DateTime EntryDt { get; set; }
        // Date and time of payment for the parking
        public DateTime? PaymentDt { get; set; }
        // Date and time of exiting the parking
        public DateTime? ExitDt { get; set; }
        // Total cost of parking
        public decimal? TotalPayment { get; set; }
        // Plate number of the visitor's car
        public string CarPlateNumber { get; set; }
        // Issued printed ticket
        public int TicketNumber { get; set; }

        public ParkingSession() { }

        public ParkingSession(DateTime currentTime, string carPlateNumber, int ticketNumber)
        {
            EntryDt = currentTime;
            CarPlateNumber = carPlateNumber;
            TicketNumber = ticketNumber;
        }

        // Used in ParkingManager
        public static int GenerateTicketNumber()
        {
            return rand.Next(1, int.MaxValue);
        }

        public override string ToString()
        {
            return $"You observe ParkingSession\nCarPlateNumber: {CarPlateNumber}, TicketNumber: {TicketNumber}, EntryDT: {EntryDt}, " +
                $"PaymentDT: {PaymentDt}, ExitDT: {ExitDt}, TotalPayment: {TotalPayment}.";
        }
    }
}
