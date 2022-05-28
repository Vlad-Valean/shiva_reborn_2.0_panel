using ShivaReborn.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ShivaReborn.Services.Abstractions;

public interface IIdentityService
{
    Task<ActionResponse> Login(LoginRequest request);
    Task<ActionResponse<string>> Register(RegisterRequest request, string role);
}