namespace Task1.Models;

internal class Entrance
{
    public int Number { get; init; }

    public List<Floor> Floors { get; } = new List<Floor>();
}
