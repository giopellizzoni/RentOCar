namespace BuildingBlocks.Abstractions;

public interface IIdentifiable<T>
{
    T Id { get; set; }
}
