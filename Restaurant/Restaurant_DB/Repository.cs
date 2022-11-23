using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Restaurant_DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Restaurant_DB
{
    public class Repository
    {

        //SignUp
        public void Sign_Up(string name, string type, string email, long key, string password)
        {
            using (var ctx = new RestaurantContext())
            {
                DateTime now = DateTime.Now;
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = ("dbo.Sign_Up");
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("ID", long.Parse((now.Year.ToString() + now.Month + now.Day + now.Hour + now.Minute + now.Second).ToString())));
                    command.Parameters.Add(new SqlParameter("name", name));
                    command.Parameters.Add(new SqlParameter("type", type));
                    command.Parameters.Add(new SqlParameter("email", email));
                    command.Parameters.Add(new SqlParameter("key", key));
                    command.Parameters.Add(new SqlParameter("password", password));


                    ctx.Database.OpenConnection();

                    command.ExecuteNonQuery();
                    ctx.Database.CloseConnection();
                }
            }
        }


        public long Get_Key(string email)
        {
            long key;
            using (var ctx = new RestaurantContext())
            {
                List<string> categories = new List<string>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [User] WHERE Email = '" + email + "'";

                    ctx.Database.OpenConnection();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return Convert.ToInt64(reader["key"]);
                    }

                }
                ctx.Database.CloseConnection();
                return 0;
            }
        }

        //Login
        public long Log_In(string email, string password)
        {
            using (var ctx = new RestaurantContext())
            {
                List<string> categories = new List<string>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [User] WHERE email = '"+email+ "' AND [password] = '" + password + "'";

                    ctx.Database.OpenConnection();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())                            
                            return Convert.ToInt64(reader["ID"]);

                    }

                }
                ctx.Database.CloseConnection();
                return 0;
            }
        }

        //List all Tables that are closed
        public List<string> ListTablesTaken()
        {
            using (var ctx = new RestaurantContext())
            {
                List<string> tables = new List<string>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT Table_number FROM [order] WHERE [Status] = 'Open'";

                    ctx.Database.OpenConnection();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(Convert.ToString(reader["Category"]));
                        }
                    }
                }
                ctx.Database.CloseConnection();
                return tables;
            }
        }
        
        //List all Categories
        public List<string> List_Categories()
        {
            using (var ctx = new RestaurantContext())
            {
                List<string> categories = new List<string>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT DISTINCT Category FROM Menu_Item ";

                    ctx.Database.OpenConnection();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(Convert.ToString(reader["Category"]));
                        }
                    }

                }
                ctx.Database.CloseConnection();
                return categories;
            }
        }

        //List by Category
        public List<Models.MenuItem> List_Item_By_Category(string category)
        {
            using (var ctx = new RestaurantContext())
            {
                List<MenuItem> items = new List<MenuItem>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Menu_Item WHERE Category = '" + category + "'";

                    ctx.Database.OpenConnection();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new MenuItem(Convert.ToInt64(reader["id"]), Convert.ToString(reader["Name"]), Convert.ToDecimal(reader["Price"])));
                        }
                    }

                }
                ctx.Database.CloseConnection();
                return items;
            }
        }

        //Create
        public void Add_Order(long user, long item, int table, List<MenuItem> items)
        {
            using (var ctx = new RestaurantContext())
            {
                DateTime now = DateTime.Now;
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = ("dbo.Begin_Order");
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("ID", long.Parse((now.Year.ToString() + now.Month + now.Day + now.Hour + now.Minute + now.Second).ToString())));
                    command.Parameters.Add(new SqlParameter("ID_User", user));
                    command.Parameters.Add(new SqlParameter("Table_num", table));

                    ctx.Database.OpenConnection();

                    command.ExecuteNonQuery();
                    ctx.Database.CloseConnection();
                }

                foreach (MenuItem i in items)
                {
                    using (var command = ctx.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = ("dbo.Add_Item_Order");
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("ID_Order", long.Parse((now.Year.ToString() + now.Month + now.Day + now.Hour + now.Minute + now.Second).ToString())));
                        command.Parameters.Add(new SqlParameter("ID_Menu_Item", i.Id));

                        ctx.Database.OpenConnection();

                        command.ExecuteNonQuery();
                        ctx.Database.CloseConnection();
                    }
                }
            }
        }

        //Update
        public void Update_Order(int Table_number)
        {
            using (var ctx = new RestaurantContext())
            {
                DateTime now = DateTime.Now;
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = ("dbo.Update_Order");
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("Table_num", Table_number));

                    ctx.Database.OpenConnection();

                    command.ExecuteNonQuery();
                    ctx.Database.CloseConnection();
                }
            }
        }

        //Delete
        public long Log_In(MenuItem item)
        {
            using (var ctx = new RestaurantContext())
            {
                List<string> categories = new List<string>();
                using (var command = ctx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "DELETE FROM Menu_Item WHERE Id = '" + item.Id + "'";

                    ctx.Database.OpenConnection();
                    command.ExecuteNonQuery();

                }
                ctx.Database.CloseConnection();
                return 0;
            }
        }
    }
}
