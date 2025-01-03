using Task1_ContractorV1.Model;

namespace Task1_ContractorV1.Repository
{
    public interface IContractorRepo
    {
        public List<Contractor> GetContractorInfo(string NOCIDB, string? SSMNO = null, string? NAMASYARIKAT=null);
    }
}
