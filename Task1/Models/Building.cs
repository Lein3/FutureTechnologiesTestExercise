namespace Task1.Models;

internal class Building
{
    public int Number { get; init; }

    public List<Entrance> Entrances { get; } = new List<Entrance>();
}
