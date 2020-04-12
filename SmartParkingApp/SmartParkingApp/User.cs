namespace ParkingApp
{
    class User
    {
        public string Name { get; set; }
        public string CarPlateNumber { get; set; }
        public string Phone { get; set; }
        public int? TicketNumber { get; set; }

        public User(string name, string carNumber, string phone)
        {
            Name = name;
            CarPlateNumber = carNumber;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Car number = {CarPlateNumber}, Phone = {Phone}.";
        }
    }
}
