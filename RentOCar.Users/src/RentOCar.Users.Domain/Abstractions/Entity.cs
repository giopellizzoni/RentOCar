namespace RentOCar.Users.Domain.Abstractions;

public class Entity<T>: IIdentifiable<T>, IAuditable
{
    public T Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
