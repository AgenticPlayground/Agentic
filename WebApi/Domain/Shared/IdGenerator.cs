using System.Net;
using System.Net.Sockets;

namespace WebApi.Domain.Shared;

public static class IdGenerator
{
    private static readonly IdGen.IdGenerator Generator = new(GetUniqueGeneratorIdFromIpAddress());

    public static long NewId()
    {
        return Generator.CreateId();
    }

    private static int GetUniqueGeneratorIdFromIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        const string noNetworkAdapters = "No network adapters with an IPv4 address in the system. IdGenerator is meant to create unique IDs across multiple machines, and requires an IP address to do so.";
        var ipAddress = Array.Find(host.AddressList, ip => ip.AddressFamily == AddressFamily.InterNetwork)
                        ?? throw new InvalidOperationException(noNetworkAdapters);

        var lastSegment = ipAddress.ToString().Split('.')[3];
        return int.Parse(lastSegment);
    }
}