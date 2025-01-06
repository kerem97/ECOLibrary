using AutoMapper;
using ECOLibrary.BusinessLayer.Services.UserService;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DTOs.User.Requests;
using ECOLibrary.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //public async Task<List<UserListResponse>> GetAllUsersAsync()
        //{
        //    var users = await _userRepository.GetAllAsync();
        //    return _mapper.Map<List<UserListResponse>>(users);
        //}

        //public async Task<UserByIdResponse> GetUserByIdAsync(string id)
        //{
        //    var user = await _userRepository.GetByIdAsync(id);
        //    return _mapper.Map<UserByIdResponse>(user);
        //}

        public async Task AddUserAsync(UserCreateRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(UserUpdateRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
