﻿using Northwind.Contract.AuthenticationWebAPI;

namespace Northwind.WebAPI.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        string GenerateRefreshToken();
    }
}
