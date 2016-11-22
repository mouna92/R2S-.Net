using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using R2S.Data.Models;
using R2S.Service;

namespace R2S.GUI.Models
{
    public class User : user, IUser<long>
    {
        public long Id { get { return cin; } }
        public string UserName { get { return username; } set { username = value; } }

        public string Role { get; set; }
    }

    public class MyPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return CalculateMd5Hash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(HashPassword(providedPassword), StringComparison.OrdinalIgnoreCase) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }

        public string CalculateMd5Hash(string input)

        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);


            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }

    public class UserManager : UserManager<User, long>
    {
        public UserManager(IUserStore<User, long> store) : base(store)
        {
           this.PasswordHasher = new MyPasswordHasher();
        }
    }

    public class SignInService : SignInManager<User, long>
    {
        public SignInService(UserManager<User, long> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }


    }

    public class UserStore : IUserStore<User, long>, IUserPasswordStore<User, long>, IUserRoleStore<User, long>, IUserLockoutStore<User, long>, IUserTwoFactorStore<User, long>
    {

        private IUserService _userService;
        public UserStore(IUserService userService)
        {
            _userService = userService;
        }

        public void Dispose()
        {
            if (_userService != null)
            {
                //_userService.Dispose();
                //_userService = null;
            }
        }

        public Task CreateAsync(User user)
        {
            _userService.Add(user);


            return Task.FromResult(user);
        }

        public Task UpdateAsync(User user)
        {
            _userService.Update(user);

            return Task.FromResult(user);
        }

        public Task DeleteAsync(User user)
        {
            _userService.Delete(user);

            return Task.FromResult(user);
        }

        public Task<User> FindByIdAsync(long userId)
        {
            user u = _userService.GetById(userId);

            if (u == null)
            {
                 return Task.FromResult<User>(null);
            }
            User user = new User()
            {
                cin = u.cin,
                password = u.password,
                username = u.username,
                firstname =  u.firstname,
                lastname = u.lastname,
                Role = u is RecruitementManager ? "RecruitmentManager" : (u is ChiefHumanRessource ? "ChiefHumanResourcesOfficer" : "NotAllowed")
            };

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var users = _userService.GetMany(user => user.username == userName).ToList(); 
            
            if (users != null && users.Count > 0 && users[0] != null)
            {
                user u = users[0];
                System.Diagnostics.Debug.WriteLine("u: "+u);
                User u1 = new User()
                {
                    cin = u.cin,
                    password = u.password, 
                    username = u.username,
                    firstname = u.firstname,
                    lastname = u.lastname,
                    Role = u is RecruitementManager ? "RecruitmentManager" : (u is ChiefHumanRessource ? "ChiefHumanResourcesOfficer" : "NotAllowed")
                };

                return Task.FromResult(u1);
            }

            return Task.FromResult<User>(null);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            IList<string> roles = new List<string>() { user.Role };
            
            return Task.FromResult(roles);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return Task.FromResult(user.Role == roleName);
        }


        #region LockoutStore
        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.Factory.StartNew<bool>(() => false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user) { 
        
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }
        #endregion

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }
    }

    //ROLES
    public class Role : IRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleManager : RoleManager<Role, int>
    {
        public RoleManager(IRoleStore<Role, int> store) : base(store)
        {
            this.RoleValidator = new RoleValidator<Role, int>(this);
        }
    }

    public class RoleStore : IRoleStore<Role, int>
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            Role role = null;
            if (roleId == 1)
            {
                role = new Role() {Id = 1, Name = "ChiefHumanResourcesOfficer" };
            }else if (roleId == 2)
            {
                role = new Role() { Id = 2, Name = "Employee" };
            }

            return Task.FromResult(role);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            Role role = null;
            if (roleName == "ChiefHumanResourcesOfficer")
            {
                role = new Role() { Id = 1, Name = "ChiefHumanResourcesOfficer" };
            }
            else if (roleName == "RecruitmentManager")
            {
                role = new Role() { Id = 2, Name = "RecruitmentManager" };
            }

            return Task.FromResult(role);
        }
    }
}