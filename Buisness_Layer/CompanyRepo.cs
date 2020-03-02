using Buisness_Layer.DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer
{
    public class CompanyRepo : ICompany
    {
        private AngularAppCompanyEntities _angularAppCompanyEntities;
        public CompanyRepo(AngularAppCompanyEntities dbContext)
        {
            _angularAppCompanyEntities = dbContext;
        }
        public bool CreateCompany(Company company)
        {
            company.CreatedDate = DateTime.Now;
            _angularAppCompanyEntities.Companies.Add(company);
            return Save();
        }

        public bool DeleteCompany(int Id)
        {
            var deleteUser = _angularAppCompanyEntities.Companies.Where(a => a.Id == Id).FirstOrDefault();
            deleteUser.Active = false;
            return Save();
        }
         
        public CompanyUpdateDTO GetCompanyDetail(int Id)
        {
            var results = _angularAppCompanyEntities.Companies.Where(a => a.Id == Id).FirstOrDefault();

            CompanyUpdateDTO companyUpdateDTO = new CompanyUpdateDTO();

            companyUpdateDTO.Id = results.Id;
            companyUpdateDTO.CompanyName = results.CompanyName;
            companyUpdateDTO.SystemName = results.SystemName;
            companyUpdateDTO.IssueType = results.IssueType;
            companyUpdateDTO.ClassName = results.ClassName;
            companyUpdateDTO.MethodName = results.MethodName;
            companyUpdateDTO.RequestDate = results.RequestDate.GetValueOrDefault().ToString();
            companyUpdateDTO.RequestNumber = results.RequestNumber.GetValueOrDefault();
            companyUpdateDTO.RequestName = results.RequestName.GetValueOrDefault();
            companyUpdateDTO.Status = results.Status.GetValueOrDefault();
            companyUpdateDTO.Comment = results.Comment;
            companyUpdateDTO.Error = results.Error;
            companyUpdateDTO.Active = results.Active.GetValueOrDefault();
           

            return (companyUpdateDTO);
        }

        public List<CompanyDtoView> GetCompanyDetails()
        {
            var ressults = _angularAppCompanyEntities.Companies.Where(a => a.Active == true).OrderBy(a => a.Id).ToList();
            List<CompanyDtoView> companyDtoViews = new List<CompanyDtoView>();

            foreach (var item in ressults)
            {
                CompanyDtoView companyDtoView = new CompanyDtoView();
                companyDtoView.Id = item.Id;
                companyDtoView.CompanyName = item.CompanyName;
                companyDtoView.SystemName = item.SystemName;
                companyDtoView.IssueType = item.IssueType;
                companyDtoView.ClassName = item.ClassName;
                companyDtoView.MethodName = item.MethodName;
                companyDtoView.RequestDate = item.RequestDate.ToString();
                companyDtoView.RequestNumber = item.RequestNumber.GetValueOrDefault();
                companyDtoView.RequestName = item.User_Information.DisplayName;
                companyDtoView.Status = item.Status1.Name;
                companyDtoView.Comment = item.Comment;
                companyDtoView.Error = item.Error;
                companyDtoView.DueDays = (item.RequestDate.GetValueOrDefault() - DateTime.Now).Days;

                companyDtoViews.Add(companyDtoView);
            }
            return (companyDtoViews);
        }

        public List<StatusDTO> GetStatus()
        {
            var result = _angularAppCompanyEntities.Status.OrderBy(a => a.Id).ToList();
            List<StatusDTO> statusCollection = new List<StatusDTO>();

            foreach (var item in result)
            {
                StatusDTO status = new StatusDTO();

                status.StatusId = item.Id;
                status.StatusName = item.Name;

                statusCollection.Add(status);
            }
            return statusCollection;
        }

        public bool Save()
        {
            var save = _angularAppCompanyEntities.SaveChanges();
            return save >= 0 ? true : false;  
        }

        public bool UpdateCompany(Company company)
        {
            var user = _angularAppCompanyEntities.Companies.Where(a => a.Id == company.Id).FirstOrDefault();

            user.Id = company.Id;
            user.CompanyName = company.CompanyName;
            user.SystemName = company.SystemName;
            user.IssueType = company.IssueType;
            user.ClassName = company.ClassName;
            user.MethodName = company.MethodName;
            user.RequestDate = company.RequestDate;
            user.RequestNumber = company.RequestNumber;
            user.RequestName = company.RequestName;
            user.Status = company.Status;
            user.Comment = company.Comment;
            user.Error = company.Error;
            user.Active = company.Active;
            user.CreatedDate = user.CreatedDate;
            user.ModefiedDate = DateTime.Now;

            return Save();
        }
    }
}
