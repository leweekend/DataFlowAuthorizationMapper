using DataFlowAuthorizationMapper.Attributes;

namespace DataFlowAuthorizationMapper.Tests.Models
{
    internal class DomainModel
    {
        [DataFlowAuthorize("admin,superuser")]
        public string FirstName { get; set; } = null!;

        [DataFlowAuthorize("admin,superuser")]
        [MapTo("Surname")]
        public string LastName { get; set; } = null!;

        [DataFlowAuthorize("member")]
        public int? Age { get; set; }
    }
}
