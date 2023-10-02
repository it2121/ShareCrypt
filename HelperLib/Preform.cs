using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelperLib;
using HelperLib.Models;
using static HelperLib.Tools;
using Dapper;

namespace HelperLib
{
    public static class Preform
    {

        public static void InsertFF(Users user, FF ff)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    Name = ff.Name,
                    Type = ff.Type,
                    Data = ff.Data,
                    Size = ff.Size,
                    OwnerID = user.ID,
                    Date = ff.Date

                };

               
                string sql = "dbo.InsertFF";


                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);

             

             
            }
        }
        public static IEnumerable<Users> GetAllUsers()
        {
            //string text = "";
            IEnumerable<Users> FFs ;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = "dbo.GetAllUsers";

                 FFs = cnn.Query<Users>(sql);

             /*   foreach (var p in FFs)
                {
                    text+= $"{p.Username} {p.Email} {p.Fullname}";
                }*/
            }
            return FFs;
        }

        public static IEnumerable<FF> GetAllFF()
        {
            //string text = "";
            IEnumerable<FF> FFs;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = "dbo.GetAllFF";

                FFs = cnn.Query<FF>(sql);

                /*   foreach (var p in FFs)
                   {
                       text+= $"{p.Username} {p.Email} {p.Fullname}";
                   }*/
            }
            return FFs;
        }
        public static Users LogIn(string username1,string password1)
        {
         
  
            //string text = "";
            IEnumerable<Users> FFs ;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    Username = username1,
                    Password = password1

                };

                string sql = "dbo.LogIn";
                FFs = cnn.Query<Users>(sql, pp, commandType: CommandType.StoredProcedure);

              

                /*   foreach (var p in FFs)
                   {
                       text+= $"{p.Username} {p.Email} {p.Fullname}";
                   }*/
            }
            Users u=null;
            foreach (var p in FFs) 
            {
              u= p;
            }
            return u;
        
        }
        public static FF GetFF(FF ff)
        {


            //string text = "";
            IEnumerable<FF> FF;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    FFID=ff.FFID

                };

                string sql = "dbo.GetFF";
                FF = cnn.Query<FF>(sql, pp, commandType: CommandType.StoredProcedure);



                /*   foreach (var p in FFs)
                   {
                       text+= $"{p.Username} {p.Email} {p.Fullname}";
                   }*/
            }
            FF u = null;
            foreach (var p in FF)
            {
                u = p;
            }
            return u;

        }
    }
}
