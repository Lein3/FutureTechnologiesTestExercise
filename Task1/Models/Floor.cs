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
    /// Список квартир на этаже.
    /// </summary>
    public List<Flat> Apartments { get; } = new List<Flat>();
}
