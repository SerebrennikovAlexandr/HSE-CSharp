public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CarPlateNumber { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }

    public User(int id, string name, string carPlateNumber, string phone, string password)
    {
        Id = id;
        Name = name;
        CarPlateNumber = carPlateNumber;
        Phone = phone;
        Password = password;
    }
}
