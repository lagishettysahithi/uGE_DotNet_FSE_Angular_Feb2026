using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;
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
            SqlConnection con = new SqlConnection(connStr);

            while (true)
            {
                Console.WriteLine("\n1.Insert\n2.View\n3.Update\n4.Delete\n5.Exit");
                Console.Write("Enter choice: ");
                int ch = int.Parse(Console.ReadLine());

                try
                {
                    // DISCONNECTED OBJECTS
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    //  VIEW
                    if (ch == 2)
                    {
                        da.SelectCommand = new SqlCommand("sp_GetAllProducts", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.Fill(ds, "Products");

                        DataTable dt = ds.Tables["Products"];

                        foreach (DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                                row["product_id"] + " " +
                                row["product_name"] + " " +
                                row["model_year"] + " " +
                                row["list_price"] + " " +
                                row["category_id"]);
                        }
                    }

                    //  INSERT
                    else if (ch == 1)
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Year: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.Write("Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Console.Write("CategoryId: ");
                        int cat = int.Parse(Console.ReadLine());

                        da.InsertCommand = new SqlCommand("sp_InsertProduct", con);
                        da.InsertCommand.CommandType = CommandType.StoredProcedure;

                        da.InsertCommand.Parameters.AddWithValue("@product_name", name);
                        da.InsertCommand.Parameters.AddWithValue("@model_year", year);
                        da.InsertCommand.Parameters.AddWithValue("@list_price", price);
                        da.InsertCommand.Parameters.AddWithValue("@category_id", cat);

                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        con.Close();

                        Console.WriteLine("Inserted Successfully");
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

                        da.UpdateCommand = new SqlCommand("sp_UpdateProduct", con);
                        da.UpdateCommand.CommandType = CommandType.StoredProcedure;

                        da.UpdateCommand.Parameters.AddWithValue("@product_id", id);
                        da.UpdateCommand.Parameters.AddWithValue("@product_name", name);
                        da.UpdateCommand.Parameters.AddWithValue("@model_year", year);
                        da.UpdateCommand.Parameters.AddWithValue("@list_price", price);
                        da.UpdateCommand.Parameters.AddWithValue("@category_id", cat);

                        con.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        con.Close();

                        Console.WriteLine("Updated Successfully");
                    }

                    // DELETE
                    else if (ch == 4)
                    {
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());

                        da.DeleteCommand = new SqlCommand("sp_DeleteProduct", con);
                        da.DeleteCommand.CommandType = CommandType.StoredProcedure;

                        da.DeleteCommand.Parameters.AddWithValue("@product_id", id);

                        con.Open();
                        da.DeleteCommand.ExecuteNonQuery();
                        con.Close();

                        Console.WriteLine("Deleted Successfully");
                    }
                    //  GET BY ID ⭐ (NEW)
                    else if (ch == 5)
                    {
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());

                        da.SelectCommand = new SqlCommand("sp_GetProductById", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand.Parameters.AddWithValue("@product_id", id);

                        da.Fill(ds, "Product");

                        if (ds.Tables["Product"].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables["Product"].Rows)
                            {
                                Console.WriteLine(
                                    row["product_id"] + " " +
                                    row["product_name"] + " " +
                                    row["model_year"] + " " +
                                    row["list_price"] + " " +
                                    row["category_id"]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Product not found");
                        }
                    }

                    //  EXIT
                    else if (ch == 5)
                    {
                        break;
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

