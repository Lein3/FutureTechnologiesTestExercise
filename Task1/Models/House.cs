namespace Task1.Models;

/// <summary>
/// Класс, представляющий информацию о доме.
/// </summary>
public class House
{
    /// <summary>
    /// Номер дома
    /// </summary>
    public int Number { get; init; }

    /// <summary>
    /// Список подъездов в доме.
    /// </summary>
    public List<Entrance> Entrances { get; init; }

    /// <summary>
    /// Инициализирует новый экземпляр класса House с указанным номером.
    /// </summary>
    /// <param name="number">Номер дома.</param>
    public House(int number)
    {
        Number = number;
        Entrances = new List<Entrance>();
    }

    /// <summary>
    /// Находит квартиру по указанному номеру.
    /// </summary>
    /// <param name="flatToFind">Номер квартиры для поиска.</param>
    /// <returns>Объект квартиры с указанным номером.</returns>
    /// <exception cref="InvalidOperationException">Когда квартира с указанным номером отсутствует в доме</exception>
    public Flat FindFlat(int flatToFind)
    {
        return Entrances
            .SelectMany(entrance => entrance.Floors)
            .SelectMany(floor => floor.Flats)
            .First(flat => flat.Number == flatToFind);
    }
}
