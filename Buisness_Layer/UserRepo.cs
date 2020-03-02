using Buisness_Layer.DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer
{
    public class UserRepo : IUserRepo
    {
        private AngularAppCompanyEntities _AngularAppCompanyEntities;
        public UserRepo(AngularAppCompanyEntities dbContext)
        {
            _AngularAppCompanyEntities = dbContext;
        }
        public bool CreateUser(User_Information userInformation)
        {
            userInformation.Created = DateTime.Now;
            _AngularAppCompanyEntities.User_Information.Add(userInformation);
            return Save();
        }

        public bool DeleteUser(int UserId)
        {
            var user =_AngularAppCompanyEntities.User_Information.Where(a => a.Id == UserId).SingleOrDefault();
            user.Active = false;
            return Save();
        }

        public GetUsersDTO GetUserInformation(int GetUserId)
        {
            var user = _AngularAppCompanyEntities.User_Information.Where(a => a.Id == GetUserId).Where(a => a.Active == true).SingleOrDefault();

            GetUsersDTO getUsersDTO = new GetUsersDTO();
            getUsersDTO.Id = user.Id;
            getUsersDTO.AccountName = user.AccountName;
            getUsersDTO.DisplayName = user.DisplayName;
            getUsersDTO.Email = user.Email;
            getUsersDTO.Designation = user.Designation;
            getUsersDTO.Department = user.Department;
            getUsersDTO.Created = user.Created.ToString();
            return (getUsersDTO);
        }

        public ICollection<GetUsersDTO> GetUserInformations()
        {
            var users = _AngularAppCompanyEntities.User_Information.OrderBy(a => a.Id).Where(a => a.Active == true).ToList();
            List<GetUsersDTO> usersDTOList = new List<GetUsersDTO>();
            foreach (var item in users)
            {
                GetUsersDTO getUsersDTO = new GetUsersDTO();
                getUsersDTO.Id = item.Id;
                getUsersDTO.AccountName = item.AccountName;
                getUsersDTO.DisplayName = item.DisplayName;
                getUsersDTO.Email = item.Email;
                getUsersDTO.Designation = item.Designation;
                getUsersDTO.Department = item.Department;
                getUsersDTO.Created = item.Created.ToString();

                usersDTOList.Add(getUsersDTO);
            }

            return (usersDTOList);
        }

        public bool Save()
        {
            var save = _AngularAppCompanyEntities.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateUser(User_Information userInformation)
        {
            var UserOld = _AngularAppCompanyEntities.User_Information.Where(a => a.Id == userInformation.Id).SingleOrDefault();

            UserOld.Id = userInformation.Id;
            UserOld.AccountName = userInformation.AccountName;
            UserOld.DisplayName = userInformation.DisplayName;
            UserOld.Email = userInformation.Email;
            UserOld.Designation = userInformation.Designation;
            UserOld.Active = userInformation.Active;
            UserOld.Created = UserOld.Created;
            UserOld.Modefied = DateTime.Now;
                   
           // _AngularAppCompanyEntities.Entry(userInformation).State = EntityState.Modified;
            return Save();
        }
    }
}
