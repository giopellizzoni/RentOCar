namespace RentOCar.Users.Application.Models;

public record UserOutputModel
{
    public string Name { get; set; }

    public string Document { get; set; }

    public DateTime BirthDate { get; set; }

    public string Email { get; set; }

    public AddressModel Address { get; private set; }

    public UserOutputModel(string name, string document, DateTime birthDate, string email, AddressModel address)
    {
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Email = email;
        Address = address;
    }

    public static UserOutputModel FromUser(User user)
    {
        return new UserOutputModel(
            user.Name.ToString() ?? string.Empty,
            user.Document.ToString() ?? string.Empty,
            user.BirthDate,
            user.Email.ToString() ?? string.Empty,
            AddressModel.FromAddress(user.Address)
        );
    }
}
