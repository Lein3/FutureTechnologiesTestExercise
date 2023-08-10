namespace Task1.Models;

/// <summary>
/// Класс, представляющий информацию о доме.
/// </summary>
public class Building
{
    /// <summary>
    /// Номер дома
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Список подъездов в доме.
    /// </summary>
    public List<Entrance> Entrances { get; } = new List<Entrance>();
}
