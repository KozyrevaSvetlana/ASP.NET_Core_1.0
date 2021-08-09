using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IRolesRepository
    {
        IEnumerable<RoleViewModel> AllRoles { get; }

        void Add(string name);
        void DeleteRole(string name);
        void Edit(string newName, string name);
        RoleViewModel GetRoleByName(string name);
        List<string> IsValid(string name);
    }
}