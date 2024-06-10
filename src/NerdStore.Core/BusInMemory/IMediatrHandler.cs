using NerdStore.Core.Messages;

namespace NerdStore.Core.BusInMemory
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
