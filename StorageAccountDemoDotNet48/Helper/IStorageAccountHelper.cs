using System.Threading.Tasks;

namespace StorageAccountDemoDotNet48.Helper
{
    public interface IStorageAccountHelper
    {
        Task CreateBlockBlobAsync(string accountName, string containerName, string blobName);
    }
}