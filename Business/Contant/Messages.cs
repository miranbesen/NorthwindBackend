using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contant
{
    public static class Messages
    {
        public static string ProductAdded = "Product add is successful";
        public static string ProductDeleted = "Product delete is successful";
        public static string ProductUpdated = "Product update is successful";
        public static string CategorieAdded = "Categorie add is successful";
        public static string CategorieDeleted = "Categorie delete is successful";
        public static string CategorieUpdated = "Categorie update is successful";

        public static string UserNotFound = "User not found";
        public static string PasswordError="Password isn't true";
        public static string SuccessfullLogin="Login is succesfull";
        public static string UserAlreadyExists="User Already Exists";
        public static string UserRegistered="User register is success";
        public static string AccessTokenCreated="Access token created is success";
    }
}
