using ClaimSample.Core.Services.Interfaces;
using ClaimSample.Core.ViewModels;
using ClaimSample.DataLayer.Context;
using ClaimSample.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaimSample.Core.Services
{
    public class UserService : IUserService
    {
        public ClaimContext _db { get; set; }
        public UserService(ClaimContext claimContext)
        {
            _db = claimContext;
        }

        public User LoginUser(LoginViewModel loginView)
        {
            var Email = loginView.Email.ToLower();
            var Pass = loginView.Password.ToLower();
            var User = _db.users.Where(u => u.Email == Email && u.Password == Pass).FirstOrDefault();
            User.LastLogin = DateTime.Now;
            _db.users.Update(User);
            _db.SaveChanges();
            return User;
        }

        public void addUser(User user)
        {
            var fuser = user;
            if (fuser.Username == null) { fuser.Username = fuser.Email; }
            _db.users.Add(fuser);

            _db.SaveChanges();

        }
    }
}
