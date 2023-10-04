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

        public static void MoveOwnedFF(OwnedFF OwnedFf, FF ff)
        {
            
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    ParantID = OwnedFf.ParantID,
                    @FFID = ff.FFID
                  

                };


                string sql = "dbo.MoveOwnedFF";


                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);




            }
        }  public static void DeleteFFAndOwnedFF(FF ff)
        {
            
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    FFID = ff.FFID
                  

                };


                string sql = "dbo.DeleteFFAndOwnedFF";


                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);




            }
        }
        public static void InsertOwnedFF(Users user, int ffid, int parantID)
        {
            
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    UserID = user.ID,
                    FFID = ffid,
                    ParantID = parantID

                };


                string sql = "dbo.InsertOwnedFF";


                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);




            }
        }
        public static int InsertFF(Users user, FF ff)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
              
                var p = new DynamicParameters();
                p.Add("@FFID", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("@OwnerID", user.ID);
                p.Add("@Name", ff.Name);
                p.Add("@Type", ff.Type);
                p.Add("@Data", ff.Data,DbType.Binary);
                p.Add("@Size", ff.Size);
                p.Add("@Date", ff.Date);

                string sql = "dbo.InsertFF";


                cnn.Execute(sql, p, commandType: CommandType.StoredProcedure);

                return p.Get<int>("@FFID");


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

        public static IEnumerable<OwnedFF> GetOwnedFF(Users user)
        {



            IEnumerable<OwnedFF> FFs;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    @UserID = user.ID

                };

                string sql = "dbo.GetOwnedFF";
                FFs = cnn.Query<OwnedFF>(sql, pp, commandType: CommandType.StoredProcedure);



            }

            return FFs;

            /*  FF u=null;
            foreach (var p in FFs) 
            {
              u= p;
            }
            return u;*/

        }

        public static IEnumerable<FF> GetUserFF(Users user)
        {



             IEnumerable<FF> FFs ;
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var pp = new
                {
                    @UserID = user.ID

                };

                string sql = "dbo.GetOwnedFF";
                FFs = cnn.Query< FF>(sql, pp, commandType: CommandType.StoredProcedure);

              

            }

            return FFs;
            
            /*  FF u=null;
            foreach (var p in FFs) 
            {
              u= p;
            }
            return u;*/
        
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
