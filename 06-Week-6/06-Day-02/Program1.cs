using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // Load connection string from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connStr = config.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n1.Insert\n2.View\n3.Update\n4.Delete\n5.Exit");
                Console.Write("Enter choice: ");
                int ch = int.Parse(Console.ReadLine());

                try
                {
                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        con.Open();

                        //  INSERT
                        if (ch == 1)
                        {
                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Year: ");
                            int year = int.Parse(Console.ReadLine());

                            Console.Write("Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            Console.Write("CategoryId: ");
                            int cat = int.Parse(Console.ReadLine());

                            SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@product_name", name);
                            cmd.Parameters.AddWithValue("@model_year", year);
                            cmd.Parameters.AddWithValue("@list_price", price);
                            cmd.Parameters.AddWithValue("@category_id", cat);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Inserted Successfully");
                        }

                        //  VIEW
                        else if (ch == 2)
                        {
                            SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    reader["product_id"] + " " +
                                    reader["product_name"] + " " +
                                    reader["model_year"] + " " +
                                    reader["list_price"] + " " +
                                    reader["category_id"]);
                            }
                        }

                        //  UPDATE
                        else if (ch == 3)
                        {
                            Console.Write("ID: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Year: ");
                            int year = int.Parse(Console.ReadLine());

                            Console.Write("Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            Console.Write("CategoryId: ");
                            int cat = int.Parse(Console.ReadLine());

                            SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@product_id", id);
                            cmd.Parameters.AddWithValue("@product_name", name);
                            cmd.Parameters.AddWithValue("@model_year", year);
                            cmd.Parameters.AddWithValue("@list_price", price);
                            cmd.Parameters.AddWithValue("@category_id", cat);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Updated Successfully");
                        }

                        //  DELETE
                        else if (ch == 4)
                        {
                            Console.Write("Enter ID: ");
                            int id = int.Parse(Console.ReadLine());

                            SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@product_id", id);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Deleted Successfully");
                        }

                        // 🔹 EXIT
                        else if (ch == 5)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}