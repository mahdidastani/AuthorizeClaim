using ClaimSample.Core.ViewModels;
using ClaimSample.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClaimSample.Core.Services.Interfaces
{
   public interface IUserService
    {
        User LoginUser(LoginViewModel loginView);


        void addUser(User user);
    }
}
