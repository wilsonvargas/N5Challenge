using System.Threading.Tasks;
using N5Challenge.Api.Contracts;
using Nest;

namespace N5Challenge.Api.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient elasticClient;
        public ElasticSearchService(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task<ISearchResponse<PermissionInformation>> GetAll()
        {
            ISearchResponse<PermissionInformation> result = await elasticClient
                                   .SearchAsync<PermissionInformation>(s => s.Query(q => q.MatchAll()));
            return result;
        }

        public async void IndexDocument(PermissionInformation permissionInformation)
        {
            await elasticClient.IndexDocumentAsync(permissionInformation);
        }

        public async void UpdateIndexDocument(PermissionInformation permissionInformation)
        {
            await elasticClient.UpdateAsync<PermissionInformation>(permissionInformation.Id,
                                                                       u => u.Index("permissions").Doc(permissionInformation));
        }
    }
}