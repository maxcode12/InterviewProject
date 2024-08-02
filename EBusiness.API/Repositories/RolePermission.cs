using EBusiness.API.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EBusiness.API.Repositories;

public class RolePermission : IRolePermission
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public RolePermission(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    //public Task<Response<object>> AddModule()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Response<List<RolePermissionDTO>>> Assign(string role)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Response<object>> Get()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Response<object>> UpdatePermission(string id, string role, bool permission, string name)
    //{
    //    throw new NotImplementedException();
    //}
}
