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
}
