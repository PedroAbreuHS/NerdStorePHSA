
namespace NerdStore.Core.Data
{
    public interface IUniteOfWork
    {
        Task<bool> Commit();
    }
}
