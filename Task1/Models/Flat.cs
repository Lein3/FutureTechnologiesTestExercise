namespace Task1.Models;

/// <summary>
/// Класс, представляющий информацию о квартире.
/// </summary>
public class Flat
{
    /// <summary>
    /// Номер квартиры.
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Этаж квартиры.
    /// </summary>
    public Floor Floor { get; init; }

    /// <summary>
    /// Позиция квартиры на лестничной площадке.
    /// </summary>
    public ApartmentPosition Position { get; set; }
}
