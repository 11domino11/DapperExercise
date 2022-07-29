using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper_exercise;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);
        //var repo = new DapperDepartmentRepository(conn);

        /* Console.WriteLine("Type a new Department Name");

         var newDepartment = Console.ReadLine();

         repo.InsertDepartment(newDepartment);

         var departments = repo.GetAllDepartments();
         foreach (var item in departments)
         {
             Console.WriteLine(item.Name);
         } */
        Console.WriteLine("Here is a list of products");
        var prod = new DapperProductRepository(conn);

        Console.WriteLine("What Product would you like to add?");
        var aProduct = Console.ReadLine();
        prod.CreateProduct(aProduct, 20, 1);

        var products = prod.GetAllProducts();

        foreach (var item in products)
        {
            Console.WriteLine($"ID:{item.ProductID} {item.Name}");
        }
    }
}