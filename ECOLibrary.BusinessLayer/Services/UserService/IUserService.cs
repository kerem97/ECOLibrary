using ECOLibrary.DTOs.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.UserService
{
    public interface IUserService
    {
        //Task<List<UserListResponse>> GetAllUsersAsync();
        //Task<UserByIdResponse> GetUserByIdAsync(string id);
        Task AddUserAsync(UserCreateRequest userDto);
        Task UpdateUserAsync(UserUpdateRequest userDto);
        Task DeleteUserAsync(string id);
    }
}
