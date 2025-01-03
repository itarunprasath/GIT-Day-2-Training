using Task1_ContractorV1.Model;
using Task1_ContractorV1.Repository;

namespace Task1_ContractorV1.Services
{
    public class ContractorService: IContractorService
    {
        public readonly IContractorRepo contractorRepo;
        private IContractorRepo _contractorRepo;

        public ContractorService(IContractorRepo contractorRepo)
        {
            _contractorRepo = contractorRepo;
        }

        public List<Contractor> GetContractorInfo(string NOCIDB, string? SSMNO, string? NAMASYARIKAT)

            {
            var ssmno = string.IsNullOrEmpty(SSMNO) ? null : SSMNO;
            var companyName = string.IsNullOrEmpty(NAMASYARIKAT) ? null : NAMASYARIKAT;

            return _contractorRepo.GetContractorInfo(NOCIDB, ssmno, companyName);

            }
    }
}
