using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.DTOs
{
    public record UserDTO(int UserId, string FullName, string Email, string Type, bool ResetPassword);

    public record LoginUserDTO(string Email, string Password);

    public record ChangePasswordUserDTO(int UserId, string NewPassword);

    public record CreateUserDTO(string FullName, string Email, string Type, string Password);

    public record UpdateUserDTO(int UserId, string FullName, string Email, string Type, bool ResetPassword);
}
