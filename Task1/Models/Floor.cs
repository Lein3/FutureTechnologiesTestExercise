namespace Task1.Models;

internal class Floor
{
    public int Number { get; init; }

    public List<Flat> Apartments { get; } = new List<Flat>();
}
