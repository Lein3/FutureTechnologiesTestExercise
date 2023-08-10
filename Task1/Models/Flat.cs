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

    /// <summary>
    /// Инициализирует новый экземпляр класса Flat с указанными параметрами.
    /// </summary>
    /// <param name="number">Номер квартиры.</param>
    /// <param name="floor">Этаж квартиры.</param>
    /// <param name="position">Позиция квартиры на лестничной площадке.</param>
    public Flat(int number, Floor floor, ApartmentPosition position)
    {
        Number = number;
        Floor = floor;
        Position = position;
    }

    /// <summary>
    /// Выводит информацию о квартире на консоль.
    /// P.S я понимаю что здесь нужно не напрямую в консоль выводить, а через логгер, но не хочу в проект ничего лишнего тащить
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Квартира {Number}");
        Console.WriteLine($"Расположение {Position}");
        Console.WriteLine($"Этаж {Floor.Number}");
        Console.WriteLine($"Подъезд {Floor.Entrance.Number}");
        Console.WriteLine($"Номер дома {Floor.Entrance.House.Number}");
    }
}
