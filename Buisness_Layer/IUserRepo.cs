using Buisness_Layer.DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer
{
    public interface IUserRepo
    {
        ICollection<GetUsersDTO> GetUserInformations();
        GetUsersDTO GetUserInformation(int GetUserId);

        bool CreateUser(User_Information userInformation);
        bool UpdateUser(User_Information userInformation);
        bool DeleteUser(int UserId);
        bool Save();
    }
}
