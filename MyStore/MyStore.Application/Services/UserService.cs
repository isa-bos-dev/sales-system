using MyStore.Application.DTOs;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Application.Services
{
    public class UserService(IUserRepository _repo)
    {
        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            var users = await _repo.GetAsync();
            return users.Select(e => new UserDTO(
                UserId: e.UserId,
                FullName: e.FullName,
                Email: e.Email,
                Type: e.Type,
                ResetPassword: e.ResetPassword
                ));
        }

        public async Task<UserDTO> GetByIdAsync(int Id)
        {
            if (Id == 0) throw new ValidationException("User Id is required");

            var user = await _repo.GetByIdAsync(Id);

            if (user is null) throw new ValidationException("User not found");

            return new UserDTO(
                UserId: user.UserId,
                FullName: user.FullName,
                Email: user.Email,
                Type: user.Type,
                ResetPassword: user.ResetPassword
                );
        }

        public async Task <UserDTO> LoginAsync(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email)) throw new ValidationException("Email is required");
            if (string.IsNullOrEmpty(Password)) throw new ValidationException("Password is required");

            var user = await _repo.LoginAsync(Email, Password);

            if(user is null) throw new ValidationException("User not found");

            return new UserDTO(
                UserId: user.UserId,
                FullName: user.FullName,
                Email: user.Email,
                Type: user.Type,
                ResetPassword: user.ResetPassword
                );
        }

        public async Task ChangePasswordAsync(ChangePasswordUserDTO data)
        {
            if (data.UserId==0) throw new ValidationException("Email is required");

            var existingUser = await _repo.GetByIdAsync(data.UserId);

            if (existingUser is null) throw new ValidationException("User not found");

            existingUser.Password = data.NewPassword;
            existingUser.ResetPassword = false;

            await _repo.EditAsync(existingUser);
        }

        public async Task AddAsync(CreateUserDTO user)
        {
            if (string.IsNullOrEmpty(user.FullName)) throw new ValidationException("Full Name is required");
            if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email is required");

            var newUser = new User { 
                FullName = user.FullName,
                Email = user.Email,
                Type = user.Type,
                Password = user.Email
            };

            await _repo.AddAsync(newUser);
        }

        public async Task UpdateAsync(UpdateUserDTO user)
        {
            if (user.UserId == 0) throw new ValidationException("User Id is required");
            if (string.IsNullOrEmpty(user.FullName)) throw new ValidationException("Full Name is required");
            if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email is required");

            var existingUser = await _repo.GetByIdAsync(user.UserId);

            if (existingUser is null) throw new ValidationException("User not found");

            if(existingUser.FullName != user.FullName)
                existingUser.FullName = user.FullName;

            if (existingUser.Email != user.Email)
                existingUser.Email = user.Email;

            if (existingUser.Type != user.Type)
                existingUser.Type = user.Type;

            if (existingUser.ResetPassword != user.ResetPassword)
                existingUser.ResetPassword = user.ResetPassword;

            await _repo.EditAsync(existingUser);
        }

        public async Task DeleteAsync(int Id)
        {
            if (Id == 0) throw new ValidationException("User Id is required");


            var user = await _repo.GetByIdAsync(Id);

            if (user is null) throw new ValidationException("User not found");

            await _repo.DeleteAsync(Id);
        }

    }
}
