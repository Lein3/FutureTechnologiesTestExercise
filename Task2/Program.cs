using System.Net;
using System.Net.Sockets;

Console.WriteLine("Введите IP адрес");
var ip = Console.ReadLine();
Console.WriteLine("Введите MAC адрес");
var mac = Console.ReadLine();
Console.WriteLine("Сколько секунд генерируем трафик?");
var secondForGenerate = Convert.ToInt32(Console.ReadLine());
int sendedPackets = 0;
int receivedPackets = 0;

IPAddress Address = IPAddress.Parse(ip);
IPEndPoint endPoint = new IPEndPoint(Address, 5000);
Console.WriteLine();

var cancellationToken = new CancellationTokenSource();
Task.Run(() => SendMessageAsync(cancellationToken.Token));
Task.Run(() => ReceiveMessageAsync(cancellationToken.Token));
await Task.Delay(secondForGenerate * 1000);
cancellationToken.Cancel();

Console.Clear();
Console.WriteLine($"Пакетов отправлено {sendedPackets}");
Console.WriteLine($"Пакетов получено {receivedPackets}");
Console.WriteLine($"Пакетов потеряно {sendedPackets - receivedPackets}");
Console.ReadLine();

async Task SendMessageAsync(CancellationToken token)
{
    using UdpClient sender = new UdpClient();
    Random random = new Random();
    const int BYTES_PER_MEGABIT = 125000;
    const int MAX_UDP_PACKET_SIZE = 65507;

    while (!token.IsCancellationRequested)
    {
        int dataRateInMbps = random.Next(1, 1000);
        int bytesCount = dataRateInMbps * BYTES_PER_MEGABIT;
        byte[] data = new byte[bytesCount];
        random.NextBytes(data);

        foreach (var chunck in SplitBuffer(data, MAX_UDP_PACKET_SIZE))
        {
            await sender.SendAsync(chunck, endPoint);
            sendedPackets++;
        }
    }
}

async Task ReceiveMessageAsync(CancellationToken token)
{
    using UdpClient receiver = new UdpClient(endPoint);
    while (!token.IsCancellationRequested)
    {
        var result = await receiver.ReceiveAsync();
        if (mac == GetMacAddressFromIp(result.RemoteEndPoint))
        {
            receivedPackets++;
            Console.WriteLine("получен пакет");
        }
    }
}

[System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

static string GetMacAddressFromIp(IPEndPoint ip)
{
    IPAddress ipAddress = IPAddress.Parse(ip.Address.ToString());
    byte[] macBytes = new byte[6];
    int length = 6;
    SendARP(BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0), 0, macBytes, ref length);
    return BitConverter.ToString(macBytes, 0, 6);
}

static List<byte[]> SplitBuffer(byte[] array, int chunkSize)
{
    List<byte[]> dividedLists = new List<byte[]>();
    int index = 0;

    while (index < array.Length)
    {
        int remaining = array.Length - index;
        int currentChunkSize = Math.Min(chunkSize, remaining);
        byte[] chunk = new byte[currentChunkSize];
        Array.Copy(array, index, chunk, 0, currentChunkSize);
        dividedLists.Add(chunk);
        index += currentChunkSize;
    }

    return dividedLists;
}