Console.WriteLine("Введите количество подъездов");
var entrancesAmount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество этажей");
int floorsAmount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите квартиру для поиска");
int flatToFind = Convert.ToInt32(Console.ReadLine());

var builder = new HouseBuilder(1);
builder.AddEntrances(entrancesAmount);
builder.AddFloors(floorsAmount);
builder.AddFlats();

try
{
    var house = builder.Build();
    var foundFlat = house.FindFlat(flatToFind);
    foundFlat.Display();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Квартиры с таким номером нет в доме");
}
Console.ReadLine();