using System;
using AutoMapper;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;
using RecipeNutrient.Services.Model;
using RecipeNutrient.Services.Helper;

namespace RecipeNutrient.Services
{
    using BCrypt.Net;
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetEntity(u => u.Email == model.Email);
            user.Role = _roleRepository.GetEntityById(user.RoleId);

            // validate user
            if (user == null || !BCrypt.Verify(model.Password, user.Password))
                throw new RecipeNutrientException("Email or password is incorrect", 400);

            // return user with token
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtHandler.GenerateToken(user);
            string token = _jwtHandler.GenerateToken(user);
            //Console.WriteLine(token);
            //AuthenticateResponse response = new AuthenticateResponse
            //{
            //    Id = user.Id,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Email = user.Email,
            //    Token = token
            //};
            return response;

        }

        public async Task<User> Register(User user)
        {
            // validate request
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new RecipeNutrientException("Email and password is required", 400);
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // check if user exist 
            var users = _userRepository.GetEntity(u => u.Email == user.Email);
            if (users != null)
            {
                throw new RecipeNutrientException("Email is already taken", 400);
                //throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            // inser user
            user.Password = BCrypt.HashPassword(user.Password);
            user.RoleId = 1;
            return await _userRepository.Insert(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task DeleteUser(User user)
        {
            user.Deleted = true;
            // delete recipes
            await _userRepository.Update(user);
        }

        public IList<User> GetUsers()
        {
            return _userRepository.GetEntities(u => u.Deleted == false).ToList();
        }

        public User GetUserById(int id)
        {
            User user = _userRepository.GetEntityById(id);
            user.Role = _roleRepository.GetEntityById(user.RoleId);
            return user;
        }
    }
}

