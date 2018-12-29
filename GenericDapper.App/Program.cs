using GenericDapper.Business.Services.Dapper;
using GenericDapper.Data.Entities;
using System;

namespace GenericDapper.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceProvider();

            Console.Write("Operation Type => ");
            int operationType = int.Parse(Console.ReadLine());

            Console.Clear();

            if(operationType == 0)
            {
                Console.Write("Table Type => ");
                int tableType = int.Parse(Console.ReadLine());
                Console.Clear();

                if (tableType == 0)
                {
                    serviceProvider.User.Insert(new User { Name = "Samet", Surname = "Şentürk" });
                }else if(tableType == 1)
                {
                    serviceProvider.Log.Insert(new Log { Description = "Description" });
                }
            }
            else if(operationType == 1)
            {
                Console.Write("Table Type => ");
                int tableType = int.Parse(Console.ReadLine());
                Console.Clear();

                if (tableType == 0)
                {
                    foreach(var item in serviceProvider.User.GetAll())
                    {
                        Console.WriteLine($"Name = {item.Name} - Surname = {item.Surname}");
                    }
                    Console.ReadKey();
                }
                else if (tableType == 1)
                {
                    foreach(var item in serviceProvider.Log.GetAll())
                    {
                        Console.WriteLine($"Description = {item.Description}");
                    }
                    Console.ReadKey();
                }
            }else if(operationType == 2)
            {
                User user = serviceProvider.User.Get("ID = 2");
                user.Name = "Abdulsamet";
                serviceProvider.User.Update(user);
            }else if(operationType == 3)
            {
                User user = serviceProvider.User.Find(2);
                Console.WriteLine($"Name = {user.Name} - Surname = {user.Surname}");
                Console.ReadKey();
            }
        }
    }
}
