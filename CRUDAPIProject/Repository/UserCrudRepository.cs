using AutoMapper;
using CRUDAPIProject.Model;
using LiteDB;
using System.Collections.Generic;
using System.Linq;
namespace CRUDAPIProject.Repository
{
    public static class UserCrudRepository
    {


        public static void InsertUser(AddUserInPutModel model)

        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
            {
                // Get user collection
                var users = db.GetCollection<Users>("users");
                //Initialize the mapper
                var configUser = new MapperConfiguration(cfg =>
                        cfg.CreateMap<AddUserInPutModel, Users>()
                        .ForMember(dest => dest.address, act => act.MapFrom(src => src.address))
                        .ForMember(dest => dest.company, act => act.MapFrom(src => src.company))
                    );

                //Using automapper
                var mapper = new Mapper(configUser);
                var mappingUser = mapper.Map<Users>(model);
                users.Insert(mappingUser);
                
            }

        }

        public static void UpdateUser(EditUserInPutModel model)

        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
            {
                // Get user collection
                var users = db.GetCollection<Users>("users");
                //Initialize the mapper
                var configUser = new MapperConfiguration(cfg =>
                        cfg.CreateMap<EditUserInPutModel, Users>()
                        .ForMember(dest => dest.address, act => act.MapFrom(src => src.address))
                        .ForMember(dest => dest.company, act => act.MapFrom(src => src.company))
                    );

                //Using automapper
                var mapper = new Mapper(configUser);
                var user = mapper.Map<EditUserInPutModel, Users>(model);

                users.Update(user);
                
            }

        }

        public static bool DeleteUser(DeleteUserInPutModel model)
        {
            //Open database (or create if not exits)
            using (var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
            {
                // Get user collection
                var users = db.GetCollection<Users>("users");

                var result = users.Find(x => x.Id == model.Id).FirstOrDefault();

                if (result == null)
                    return false;

                return users.Delete(new BsonValue(model.Id));
            }

        }

        public static Users GetUser(int Id)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
            {
                // Get user collection
                var users = db.GetCollection<Users>("users");
                var result = users.Find(x => x.Id ==Id).FirstOrDefault();
                return result;
            }

        }


        public static List<Users> GetUsers()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"NoSqlLiteDataBase.db"))
            {
                List<Users> usersList = new List<Users>();
                // Get user collection
                var users = db.GetCollection<Users>("users");
                foreach (var item in users.FindAll())
                {
                    usersList.Add(item);
                }
                return usersList;
            }

        }
    }
}