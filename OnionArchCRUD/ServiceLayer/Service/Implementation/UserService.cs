using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Service.Implementation
{
    public class UserService : IUser
    {
        private readonly AppDbContext _dbContext; 
        public UserService(AppDbContext dbContext) {

            this._dbContext = dbContext;
        }

        
        //Get all users
        public List<User> GetAllRepo()
        {
            return this._dbContext.tblUser.ToList();
        }
        //Get single user
        public User GetSingleRepo(long id)
        {
            return this._dbContext.tblUser.Find(id);
        }
        //Add User
        public string AddUserRepo(User user)
        {
            try
            {
                this._dbContext.tblUser.Add(user);
                this._dbContext.SaveChanges();
                return "Success";

            }
            catch (Exception ex) {

                return ex.Message;
            }
            
            
        }
        //Rempve user from user table
        public string RemoveUser(long id)
        {
            try
            {
                var user = this._dbContext.tblUser.Find(id);
                this._dbContext.Remove(user);
                _dbContext.SaveChanges();
                return "Succesfully removed";
            }
            catch (Exception ex) {

                return ex.Message;
            }
            
        }
        //Update user
        public string UpdateUserRepo(User user)
        {
            try
            {
                var userValue = this._dbContext.tblUser.Find(user);
                if (userValue != null)
                {
                    userValue.userName = user.userName;
                    userValue.userPhone = user.userPhone;
                    userValue.userEmailId = user.userEmailId;
                    userValue.userAddress = user.userAddress;
                    _dbContext.SaveChanges();
                    return "Successfully updated";
                }
                else
                {

                    return "No record found";
                }
            }
            catch (Exception ex) {

                return ex.Message;
            
            }
            
        }
    }
}
