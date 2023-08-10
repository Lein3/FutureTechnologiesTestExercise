namespace Task1.Models;

/// <summary>
/// Класс, представляющий информацию о подъезде.
/// </summary>
public class Entrance
{
    /// <summary>
    /// Номер подъезда.
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Зданиие, в котором расположен подъезд.
    /// </summary>
    public Building Building { get; init; }

    /// <summary>
    /// Список этажей в подъезде.
    /// </summary>
    public List<Floor> Floors { get; init; }

    public Entrance(int number, Building building)
    {
        Number = number;
        Building = building;
        Floors = new List<Floor>();
    }
}
