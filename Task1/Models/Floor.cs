namespace Task1.Models;

/// <summary>
/// Класс, представляющий информацию о этаже.
/// </summary>
public class Floor
{
    /// <summary>
    /// Номер этажа.
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Подъезд, в котором расположен этаж
    /// </summary>
    public Entrance Entrance { get; init; }

    /// <summary>
    /// Список квартир на этаже.
    /// </summary>
    public List<Flat> Flats { get; init; }

    /// <summary>
    /// Инициализирует новый экземпляр класса Floor с указанными параметрами.
    /// </summary>
    /// <param name="number">Номер этажа.</param>
    /// <param name="entrance">Подъезд, в котором расположен этаж.</param>
    public Floor(int number, Entrance entrance)
    {
        Number = number;
        Entrance = entrance;
        Flats = new List<Flat>();
    }
}
