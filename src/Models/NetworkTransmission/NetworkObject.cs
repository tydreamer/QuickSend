using System.Net;
using QuickSend.UtilityCollection;

namespace QuickSend.Models.NetworkTransmission;

internal abstract class NetworkObject
{
    protected const int BufferSize = 1024;
    
    protected NetworkObject(IPAddress? ipAddress = null)
    {
        ipAddress ??= IPAddress.Any;
        IpEndPoint = new IPEndPoint(ipAddress, Utilities.NormalPort);
        MetaDataInstance = ApplicationVariables.MetaData!;
    }
    
    protected IPEndPoint IpEndPoint { get; }
    
    protected MetaData MetaDataInstance { get; }
}