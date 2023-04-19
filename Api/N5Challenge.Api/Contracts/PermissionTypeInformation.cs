using Nest;

namespace N5Challenge.Api.Contracts
{
    public class PermissionTypeInformation
    {
        [Text(Name = "id")]
        public int Id { get; set; }
        [Text(Name = "description")]
        public string Description { get; set; }
    }
}
