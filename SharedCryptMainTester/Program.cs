using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HelperLib;
using HelperLib.Models;
using static HelperLib.Tools;
namespace SharedCryptMainTester
{
    internal class Program
    {
        static void Main(string[] args)
        {

           // GetAllUsers();
          LogIn("p1", "p1");
        }
        public static void LogIn(string username1, string password1)
        {


            //string text = "";
            IEnumerable<Users> FFs;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
               
                var pp = new
                {
                    Username = "p1",
                    Password = "p1"

                };

                string sql = "dbo.LogIn";
               // cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);

                FFs = cnn.Query<Users>(sql, pp, commandType: CommandType.StoredProcedure);

                foreach (var p in FFs)
                {
                    Console.WriteLine($"{p.Username} {p.Email} {p.Fullname}");
                }
            }
          //  return FFs.First();
        }
        public static void GetAllUsersa()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = "dbo.GetAllUsers";

                var FFs = cnn.Query<Users>(sql);

                foreach (var p in FFs)
                {
                    Console.WriteLine($"{p.Username} {p.Email} {p.Fullname}");
                }
            }
        }



        public static void GetAllUsers()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = @"Select * From Users";

                var FFs = cnn.Query<Users>(sql);

                foreach (var p in FFs)
                {
                    Console.WriteLine($"{p.Username} {p.Email} {p.Fullname}");
                }
            }
        }

/*
        public static void MapMultipleObjects()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = @"Select * From FF 
left join Users on FF.OwnerID =Users.ID ;";

                var FFs = cnn.Query<FF, Users, FF>(sql, (Ff, Users) => { Ff.User = Users; return Ff; });

                foreach (var p in FFs)
                {
                    Console.WriteLine($"{p.FFID} {p.Name} {p.Type}: Cell: {p.User?.Fullname}");
                }
            }
        }*/
    }
}
