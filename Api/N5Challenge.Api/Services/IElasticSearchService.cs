using System.Threading.Tasks;
using N5Challenge.Api.Contracts;
using Nest;

namespace N5Challenge.Api.Services
{
    public interface IElasticSearchService
    {
        void IndexDocument(PermissionInformation permissionInformation);
        Task<ISearchResponse<PermissionInformation>> GetAll();
        void UpdateIndexDocument(PermissionInformation permissionInformation);
    }
}