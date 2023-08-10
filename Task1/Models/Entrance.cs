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
    /// Список этажей в подъезде.
    /// </summary>
    public List<Floor> Floors { get; } = new List<Floor>();
}
