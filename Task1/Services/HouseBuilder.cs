namespace Task1.Services;

/// <summary>
/// Класс предоставляет механизм для гибкой настройки <see cref="House"/>
/// <br/>
/// см. Шаблон Builder
/// </summary>
public class HouseBuilder
{
    private House House { get; set; }

    private readonly int DefaultFlatAmount = 4;

    /// <summary>
    /// Инициализирует новый экземпляр класса HouseBuilder с указанным номером дома.
    /// </summary>
    /// <param name="houseNumber">Номер дома.</param>
    public HouseBuilder(int houseNumber)
    {
        House = new House(houseNumber);
    }

    /// <summary>
    /// Завершает построение дома и возвращает его.
    /// </summary>
    /// <returns>Построенный дом.</returns>
    public House Build()
    {
        return House;
    }

    /// <summary>
    /// Добавляет указанное количество подъездов в дом.
    /// </summary>
    /// <param name="entrancesAmount">Количество подъездов для добавления.</param>
    /// <returns>Текущий экземпляр HouseBuilder.</returns>
    public HouseBuilder AddEntrances(int entrancesAmount)
    {
        for (int i = 0; i < entrancesAmount; i++)
        {
            var existingAmount = House.Entrances.Count;
            House.Entrances.Add(new Entrance(existingAmount + 1, House));
        }
        return this;
    }

    /// <summary>
    /// Добавляет указанное количество этажей в каждый подъезд дома.
    /// </summary>
    /// <param name="floorsAmount">Количество этажей для добавления.</param>
    /// <returns>Текущий экземпляр HouseBuilder.</returns>
    public HouseBuilder AddFloors(int floorsAmount)
    {
        foreach (var entrance in House.Entrances)
            for (int i = 0; i < floorsAmount; i++)
            {
                var existingAmount = entrance.Floors.Count;
                entrance.Floors.Add(new Floor(existingAmount + 1, entrance));
            }

        return this;
    }

    /// <inheritdoc cref="AddFlats(int)"/>
    public HouseBuilder AddFlats()
    {
        AddFlats(DefaultFlatAmount);
        return this;
    }

    /// <summary>
    /// Добавляет указанное количество квартир на каждом этаже каждого подъезда дома.
    /// </summary>
    /// <param name="flatsAmount">Количество квартир для добавления.</param>
    /// <returns>Текущий экземпляр HouseBuilder.</returns>
    public HouseBuilder AddFlats(int flatsAmount)
    {
        foreach (var entrance in House.Entrances)
            foreach (var floor in entrance.Floors)
                for (int i = 0; i < flatsAmount; i++)
                {
                    var existingAmount = House.Entrances.SelectMany(entrance => entrance.Floors).SelectMany(floor => floor.Flats).Count();
                    var position = (ApartmentPosition)(existingAmount % 4);
                    floor.Flats.Add(new Flat(existingAmount + 1, floor, position));
                }

        return this;
    }
}
