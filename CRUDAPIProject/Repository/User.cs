using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPIProject.Model;

namespace CRUDAPIProject.Repository
{
    public class User:IUser
    {
        
    public  AddUserOutPutModel InsertUser(AddUserInPutModel  Model)
    {
        AddUserOutPutModel model=new AddUserOutPutModel();

        UserCrudRepository.InsertUser(Model);

       return model;
    }

   public  EditUserOutPutModel UpdateUser(EditUserInPutModel  Model)
   {
         EditUserOutPutModel model=new EditUserOutPutModel();

         UserCrudRepository.UpdateUser(Model);
         return model;

   }
    
   public  DeleteUserOutPutModel DeleteUser(DeleteUserInPutModel  Model)
   {
        DeleteUserOutPutModel model=new DeleteUserOutPutModel();

        model.IsDeleted=UserCrudRepository.DeleteUser(Model);
        return model;

   }
 
   public  Users GetUser(int  id)
   {
        //GetUserOutPutModel model=new GetUserOutPutModel();

       return UserCrudRepository.GetUser(id);
      

   }


   public  List<Users> GetUsers()

   {
        
        return UserCrudRepository.GetUsers();;

   }

}
}