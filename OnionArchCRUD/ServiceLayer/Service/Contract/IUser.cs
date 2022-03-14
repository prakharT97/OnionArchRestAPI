using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Service.Contract
{
    public interface IUser
    {
        //GetAll Record
        List<User> GetAllRepo();
        //GetSingle Record
        User GetSingleRepo(long id);
        //Add Record
        string AddUserRepo(User user);
        //Update or Edit Record
        string UpdateUserRepo(User user);
        //Delete
        string RemoveUser(long id);
    }
}
