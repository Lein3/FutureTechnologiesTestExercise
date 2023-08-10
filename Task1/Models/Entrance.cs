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
    public House House { get; init; }

    /// <summary>
    /// Список этажей в подъезде.
    /// </summary>
    public List<Floor> Floors { get; init; }

    /// <summary>
    /// Инициализирует новый экземпляр класса Entrance с указанным номером дома и зданием.
    /// </summary>
    /// <param name="number">Номер подъезда.</param>
    /// <param name="house">Здание, в котором расположен подъезд.</param>
    public Entrance(int number, House house)
    {
        Number = number;
        House = house;
        Floors = new List<Floor>();
    }
}
