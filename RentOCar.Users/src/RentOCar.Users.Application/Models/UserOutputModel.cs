namespace RentOCar.Users.Application.Models;

public record UserOutputModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }

    public DateTime BirthDate { get; set; }

    public string Email { get; set; }

    public AddressModel Address { get; private set; }

    public UserOutputModel(Guid id, string firstName, string lastName, string document, DateTime birthDate, string email, AddressModel address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        BirthDate = birthDate;
        Email = email;
        Address = address;
    }

    public static UserOutputModel FromUser(User user)
    {
        return new UserOutputModel(
            user.Id.Value,
            user.Name.FirstName,
            user.Name.LastName,
            user.Document.Value,
            user.BirthDate,
            user.Email.Value,
            AddressModel.FromAddress(user.Address)
        );
    }
}
