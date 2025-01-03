using Task1_ContractorV1.Model;

namespace Task1_ContractorV1.Services
{
    public interface IContractorService
    {
        public List<Contractor> GetContractorInfo(string NOCIDB, string? NOSSM = null, string? NAMASYARIKAT = null);
    }
}
