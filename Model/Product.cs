namespace OrderEntry.Model;

public record Product
{
    public int Id { get; init; }
    public string Description { get; init; }
    public string Barcode { get; init; }
}

