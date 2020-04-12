using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingAppLib.Models
{
    public class ParkingSession
    {
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
        [JsonIgnore]
        public User User { get; set; }
        public int? UserId { get; set; }
        public override string ToString()
        {
            return $"Session. EntryDt: {EntryDt}. PaymentDt: {PaymentDt}. ExitDt: {ExitDt}. TotalPayment: {TotalPayment}." +
                $"CarPlateNumber: {CarPlateNumber}. TicketNumber: {TicketNumber}. UserId: {UserId}.";
        }
    }
}
