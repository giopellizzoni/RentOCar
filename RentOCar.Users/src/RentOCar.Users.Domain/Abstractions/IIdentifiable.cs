namespace RentOCar.Users.Domain.Abstractions;

public interface IIdentifiable<T>
{
    T Id { get; set; }
}
