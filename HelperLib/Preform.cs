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
        // Move an OwnedFF to a different FF
        public static void MoveOwnedFF(OwnedFF OwnedFf, FF ff)
        {
            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    ParantID = OwnedFf.ParantID,
                    @FFID = ff.FFID
                };

                // Execute the stored procedure "MoveOwnedFF"
                string sql = "dbo.MoveOwnedFF";
                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);
            }
        }

        // Delete an FF and its associated OwnedFF entries
        public static void DeleteFFAndOwnedFF(FF ff)
        {
            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    FFID = ff.FFID
                };

                // Execute the stored procedure "DeleteFFAndOwnedFF"
                string sql = "dbo.DeleteFFAndOwnedFF";
                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);
            }
        }

        // Insert a shared entry for an FF
        public static void InsertShared(Users user, FF ff, int SharedToID)
        {
            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    OwnerID = user.ID,
                    SharedToID = SharedToID,
                    FFID = ff.FFID
                };

                // Execute the stored procedure "InsertShared"
                string sql = "dbo.InsertShared";
                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);
            }
        }

        // Insert an OwnedFF entry for a user
        public static void InsertOwnedFF(Users user, int ffid, int parantID)
        {
            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    UserID = user.ID,
                    FFID = ffid,
                    ParantID = parantID
                };

                // Execute the stored procedure "InsertOwnedFF"
                string sql = "dbo.InsertOwnedFF";
                cnn.Execute(sql, pp, commandType: CommandType.StoredProcedure);
            }
        }

        // Insert an FF entry and return the generated FFID
        public static int InsertFF(Users user, FF ff)
        {
            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define input and output parameters for the stored procedure
                var p = new DynamicParameters();
                p.Add("@FFID", 0, DbType.Int32, ParameterDirection.Output);
                p.Add("@OwnerID", user.ID);
                p.Add("@Name", ff.Name);
                p.Add("@Type", ff.Type);
                p.Add("@Data", ff.Data, DbType.Binary);
                p.Add("@Size", ff.Size);
                p.Add("@Date", ff.Date);

                // Execute the stored procedure "InsertFF"
                string sql = "dbo.InsertFF";
                cnn.Execute(sql, p, commandType: CommandType.StoredProcedure);

                // Return the generated FFID
                return p.Get<int>("@FFID");
            }
        }

        // Retrieve all users from the database
        public static IEnumerable<Users> GetAllUsers()
        {
            // Create a collection to hold user data
            IEnumerable<Users> users;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Execute a query to retrieve all users
                string sql = "dbo.GetAllUsers";
                users = cnn.Query<Users>(sql);
            }

            // Return the collection of users
            return users;
        }

        // Retrieve all FF entries from the database
        public static IEnumerable<FF> GetAllFF()
        {
            // Create a collection to hold FF data
            IEnumerable<FF> ffs;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Execute a query to retrieve all FF entries
                string sql = "dbo.GetAllFF";
                ffs = cnn.Query<FF>(sql);
            }

            // Return the collection of FF entries
            return ffs;
        }

        // Retrieve shared entries for a user
        public static IEnumerable<Shared> GetShared(Users user)
        {
            // Create a collection to hold shared entries
            IEnumerable<Shared> sharedEntries;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    @SharedToID = user.ID
                };

                // Execute the stored procedure "GetShared"
                string sql = "dbo.GetShared";
                sharedEntries = cnn.Query<Shared>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Return the collection of shared entries
            return sharedEntries;
        }

        // Retrieve OwnedFF entries for a user
        public static IEnumerable<OwnedFF> GetOwnedFF(Users user)
        {
            // Create a collection to hold OwnedFF entries
            IEnumerable<OwnedFF> ownedFFEntries;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    @UserID = user.ID
                };

                // Execute the stored procedure "GetOwnedFF"
                string sql = "dbo.GetOwnedFF";
                ownedFFEntries = cnn.Query<OwnedFF>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Return the collection of OwnedFF entries
            return ownedFFEntries;
        }

        // Retrieve FF entries from shared data
        public static IEnumerable<FF> GetFfFromShared(Users user)
        {
            // Create a collection to hold FF entries
            IEnumerable<FF> sharedFFEntries;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    @SharedToID = user.ID
                };

                // Execute the stored procedure "GetShared"
                string sql = "dbo.GetShared";
                sharedFFEntries = cnn.Query<FF>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Return the collection of FF entries from shared data
            return sharedFFEntries;
        }

        // Retrieve FF entries owned by a user
        public static IEnumerable<FF> GetUserFF(Users user)
        {
            // Create a collection to hold FF entries
            IEnumerable<FF> userFFEntries;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    @UserID = user.ID
                };

                // Execute the stored procedure "GetOwnedFF"
                string sql = "dbo.GetOwnedFF";
                userFFEntries = cnn.Query<FF>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Return the collection of FF entries owned by the user
            return userFFEntries;
        }

        // Retrieve the user's ID by username
        public static int GerUserByUsername(string username)
        {
            // Create a collection to hold user data
            IEnumerable<Users> users;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    Username = username
                };

                // Execute the stored procedure "GerUserByUsername"
                string sql = "dbo.GerUserByUsername";
                users = cnn.Query<Users>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Initialize a user object and return their ID
            Users user = null;
            foreach (var p in users)
            {
                user = p;
            }
            return user.ID;
        }

        // Log in a user by username and password
        public static Users LogIn(string username1, string password1)
        {
            // Create a collection to hold user data
            IEnumerable<Users> users;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    Username = username1,
                    Password = password1
                };

                // Execute the stored procedure "LogIn"
                string sql = "dbo.LogIn";
                users = cnn.Query<Users>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Initialize a user object and return it
            Users user = null;
            foreach (var p in users)
            {
                user = p;
            }
            return user;
        }

        // Retrieve an FF by its ID
        public static FF GetFF(FF ff)
        {
            // Create a collection to hold FF entries
            IEnumerable<FF> ffs;

            // Open a database connection
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                // Define parameters for the stored procedure
                var pp = new
                {
                    FFID = ff.FFID
                };

                // Execute the stored procedure "GetFF"
                string sql = "dbo.GetFF";
                ffs = cnn.Query<FF>(sql, pp, commandType: CommandType.StoredProcedure);
            }

            // Initialize an FF object and return it
            FF retrievedFF = null;
            foreach (var p in ffs)
            {
                retrievedFF = p;
            }
            return retrievedFF;
        }
    }

}
