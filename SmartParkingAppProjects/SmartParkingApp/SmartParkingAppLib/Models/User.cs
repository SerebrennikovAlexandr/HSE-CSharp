using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingAppLib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarPlateNumber { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public User(int id, string name, string plate, string phone, string password)
        {
            Id = id;
            Name = name;
            CarPlateNumber = plate;
            Phone = phone;
            Password = password;
        }
        public override string ToString()
        {
            return $"User. Id: {Id}. Name: {Name}. CarPlateNumber: {CarPlateNumber}. Phone: {Phone}.";
        }
    }
}
