﻿using System;

using AutoMapper;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;
using RecipeNutrient.Services.Model;
namespace RecipeNutrient.Services
{
    using BCrypt.Net;
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetEntity(u => u.Email == model.Email);

            // validate user
            if (user == null || !BCrypt.Verify(model.Password, user.Password))
                throw new Exception("Email or password is incorrect");

            // return user with token
            //var response = _mapper.Map<AuthenticateResponse>(user);
            //response.Token = _jwtHandler.GenerateToken(user);
            string token = _jwtHandler.GenerateToken(user);
            Console.WriteLine(token);
            AuthenticateResponse response = new AuthenticateResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
            return response;

        }

        public async Task<User> Register(User user)
        {
            // validate request
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Email and password is required");
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // check if user exist 
            var users = _userRepository.GetEntity(u => u.Email == user.Email);
            if (users != null)
            {
                throw new Exception("Email is already taken");
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
            return _userRepository.GetEntityById(id);
        }
    }
}

