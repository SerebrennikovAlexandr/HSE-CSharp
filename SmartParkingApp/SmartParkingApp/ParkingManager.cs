using SmartParkingApp;
using System;
using System.Collections.Generic;

namespace ParkingApp
{
    class ParkingManager
    {
        private List<ParkingSession> activeSessions = new List<ParkingSession>();
        private List<ParkingSession> completedSessions = new List<ParkingSession>();
        private readonly List<Tariff> tariffTable = new List<Tariff>();

        private int ParkingCapacity { get; set; }
        private int FreeLeavePeriod { get; set; }
        // This property is only needed for testing the program
        // All its uses must be replaced by DateTime.Now in production
        public DateTime CurrentTime { get; set; } = DateTime.Now;

        // Constructors
        public ParkingManager() { }

        public ParkingManager(int parkingCapacity)
        {
            ParkingCapacity = parkingCapacity;

            // initializing tariffTable (money, minutes)
            tariffTable.Add(new Tariff(0, 15));
            tariffTable.Add(new Tariff(50, 60));
            tariffTable.Add(new Tariff(100, 120));
            tariffTable.Add(new Tariff(140, 180));
            tariffTable.Add(new Tariff(180, 240));
            tariffTable.Add(new Tariff(225, 300));
            tariffTable.Add(new Tariff(250, 360));
            tariffTable.Add(new Tariff(275, 420));
            tariffTable.Add(new Tariff(300, 480));
            tariffTable.Add(new Tariff(325, 540));
            tariffTable.Add(new Tariff(350, 600));

            // initializing FreeLeavePeriod
            FreeLeavePeriod = tariffTable[0].Minutes;
        }

        /* BASIC PART */
        public ParkingSession EnterParking(string carPlateNumber)
        {
            // Check that there is a free parking place (by comparing the parking capacity 
            // with the number of active parking sessions). If there are no free places, return null
            if (activeSessions.Count == ParkingCapacity)
            {
                return null;
            }
                
            // Also check that there are no existing active sessions with the same car plate number,
            // if such session exists, also return null
            foreach(ParkingSession session in activeSessions)
            {
                if (session.CarPlateNumber == carPlateNumber)
                {
                    return null;
                }
            }

            // Otherwise:
            // Create a new Parking session, fill the following properties:
            // EntryDt = current date time
            // CarPlateNumber = carPlateNumber (from parameter)
            // TicketNumber = unused parking ticket number = generate this programmatically
            ParkingSession newSession = 
                new ParkingSession(CurrentTime, carPlateNumber, ParkingSession.GenerateTicketNumber());

            // Add the newly created session to the list of active sessions
            activeSessions.Add(newSession);

            // Advanced task:
            // Link the new parking session to an existing user by car plate number (if such user exists)            

            return newSession;
        }

        public bool TryLeaveParkingWithTicket(int ticketNumber, out ParkingSession session)
        {
            int sessionIndex = GetActiveParkingSessionIndex(ticketNumber);
            if(sessionIndex == -1)
            {
                session = null;
                return false;
            }

            // Check that the car leaves parking within the free leave period
            // from the PaymentDt (or if there was no payment made, from the EntryDt)
            int diff = GetTotalMinutesSinceLastPayment(sessionIndex);

            if(diff < FreeLeavePeriod)
            {
                // Complete the parking session by setting the ExitDt property
                activeSessions[sessionIndex].ExitDt = CurrentTime;
                // Move the session from the list of active sessions to the list of past sessions
                completedSessions.Add(activeSessions[sessionIndex]);
                activeSessions.RemoveAt(sessionIndex);
                // Return true and the completed parking session object in the out parameter
                session = completedSessions[completedSessions.Count - 1];
                return true;
            }

            session = null;
            return false;
        }

        /* Return the amount to be paid for the parking
         * If a payment had already been made but additional charge was then given
         * because of a late exit, this method should return the amount 
         * that is yet to be paid (not the total charge)
         */
        public decimal GetRemainingCost(int ticketNumber)
        {
            int sessionIndex = GetActiveParkingSessionIndex(ticketNumber);

            int diff = GetTotalMinutesSinceLastPayment(sessionIndex);

            if(diff >= tariffTable[tariffTable.Count - 1].Minutes)
            {
                return tariffTable[tariffTable.Count - 1].Rate;
            }

            for(int i = 0; i < tariffTable.Count - 1; i++)
            {
                if(diff <= tariffTable[i].Minutes)
                {
                   return tariffTable[i].Rate;
                }
            }

            return 0;
        }

        // For simplicity we won't make any additional validation here and always
        // assume that the parking charge is paid in full
        public void PayForParking(int ticketNumber, decimal amount)
        {
            // Save the payment details in the corresponding parking session
            // Set PaymentDt to current date and time
            int sessionIndex = GetActiveParkingSessionIndex(ticketNumber);
            activeSessions[sessionIndex].PaymentDt = CurrentTime;

            if(activeSessions[sessionIndex].TotalPayment == null)
            {
                activeSessions[sessionIndex].TotalPayment = 0;
            }

            activeSessions[sessionIndex].TotalPayment += amount;
        }

        /* ADDITIONAL TASK 2 */
        public bool TryLeaveParkingByCarPlateNumber(string carPlateNumber, out ParkingSession session)
        {
            /* There are 3 scenarios for this method:
            
            1. The user has not made any payments but leaves the parking within the free leave period
            from EntryDt:
               1.1 Complete the parking session by setting the ExitDt property
               1.2 Move the session from the list of active sessions to the list of past sessions             * 
               1.3 return true and the completed parking session object in the out parameter
            
            2. The user has already paid for the parking session (session.PaymentDt != null):
            Check that the current time is within the free leave period from session.PaymentDt
               2.1. If yes, complete the session in the same way as in the previous scenario
               2.2. If no, return false, session = null

            3. The user has not paid for the parking session:            
            3a) If the session has a connected user (see advanced task from the EnterParking method):
            ExitDt = PaymentDt = current date time; 
            TotalPayment according to the tariff table:            
            
            IMPORTANT: before calculating the parking charge, subtract FreeLeavePeriod 
            from the total number of minutes passed since entry
            i.e. if the registered visitor enters the parking at 10:05
            and attempts to leave at 10:25, no charge should be made, otherwise it would be unfair
            to loyal customers, because an ordinary printed ticket could be inserted in the payment
            kiosk at 10:15 (no charge) and another 15 free minutes would be given (up to 10:30)

            return the completed session in the out parameter and true in the main return value

            3b) If there is no connected user, set session = null, return false (the visitor
            has to insert the parking ticket and pay at the kiosk)
            */
            throw new NotImplementedException();
        }

        private int GetActiveParkingSessionIndex(int ticketNumber)
        {
            int sessionIndex = -1;
            for (int i = 0; i < activeSessions.Count; i++)
            {
                if (activeSessions[i].TicketNumber == ticketNumber)
                {
                    sessionIndex = i;
                    return sessionIndex;
                }
            }
            return sessionIndex;
        }

        private int GetTotalMinutesSinceLastPayment(int sessionIndex)
        {
            TimeSpan span;
            if (activeSessions[sessionIndex].PaymentDt != null)
            {
                span = (TimeSpan)(CurrentTime - activeSessions[sessionIndex].PaymentDt);
            }
            else
            {
                span = CurrentTime - activeSessions[sessionIndex].EntryDt;
            }

            return (int)span.TotalMinutes;
        }
    }
}
