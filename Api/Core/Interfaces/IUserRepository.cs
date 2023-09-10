using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserPaginationResponse> GetUsers(PaginationParams @params);

        Task DeleteUser(string id);

        Task<UserRolesDTO> GetUserRoles(string id);

        Task SetUserRoles(UserRolesDTO userRoles);
    }

}
