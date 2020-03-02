using Buisness_Layer.DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer
{
    public interface ICompany
    {
        List<CompanyDtoView> GetCompanyDetails();
        CompanyUpdateDTO GetCompanyDetail(int Id);
        bool CreateCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(int Id);
        bool Save();
        List<StatusDTO> GetStatus();
    }
}
