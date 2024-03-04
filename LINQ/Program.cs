using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
   
    internal class Program
    {
        
        static void PrintMenu()
        {
            Console.WriteLine("Choose (1-19):");
            Console.WriteLine("1 - Choose people older than 25 years.");
            Console.WriteLine("2 - Choose people who do not live in London.");
            Console.WriteLine("3 - Select the names of people living in Kyiv.");
            Console.WriteLine("4 - Select people older than 35 years with the name Sergey.");
            Console.WriteLine("5 -  Select people living in Odessa.");
            Console.WriteLine("6 -  Select the names and surnames of employees working in Ukraine, but not in Odessa.");
            Console.WriteLine("7 - Display the list of countries without duplicates.");
            Console.WriteLine("8 - Select 3-x first employees whose age is over 25 years.");
            Console.WriteLine("9 - Select the names, surnames and age of students from Kyiv, whose age is over 23 years old.");
            Console.WriteLine("10 -  Arrange the names and surnames of employees alphabetically, which live in Ukraine.");
            Console.WriteLine("11 - Sort employees by age in descending order. Output Id,FirstName, LastName, Age.");
            Console.WriteLine("12 - Group students by age. Output the age and how many times it is found in the list");
            Console.WriteLine("13 - Select Mobile category products whose price exceeds UAH 1,000.");
            Console.WriteLine("14 - Display the name and price of those products that do not belong to the Kitchen category,the price of which exceeds UAH 1,000.");
            Console.WriteLine("15 - Calculate the average value of all product prices.");
            Console.WriteLine("16 - Display a list of categories without duplicates.");
            Console.WriteLine("17 - Display the names and categories of goods in alphabetical order, ordered by to the name");
            Console.WriteLine("18 - Calculate the total amount of goods of the categories Сar and Mobile.");
            Console.WriteLine("19 - Display the list of categories and the quantity of goods in each category.");
            Console.WriteLine("0 - Quit");
            Console.Write("-:");

                

        }
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>(){
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
                new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
           };

            List<Department> departments = new List<Department>(){
                new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
             };

            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
            };

            List<Good> goods1 = new List<Good>()
            {
            new Good()
            { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good()
            { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good()
            { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good()
            { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good()
            { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good()
             { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good()
             { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good()
             { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good()
             { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good()
             { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };







            int choice = 1;

            try
            {
                while (choice != 0)
                {
                    Console.Clear();
                    PrintMenu();
                    choice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            var personsOver25 = from person in persons where person.Age > 25 select person;
                            PrintPersons(personsOver25);
                            break;

                        case 2:
                            var personsNotInLondon = from person in persons where person.City != "London" select person;
                            PrintPersons(personsNotInLondon);
                            break;

                        case 3:
                            var namesInKyiv = from person in persons where person.City == "Kyiv" select person.Name;
                            PrintNames(namesInKyiv);
                            break;

                        case 4:
                            var sergeyOver35 = from person in persons where person.Name == "Sergey" && person.Age > 35 select person;
                            PrintPersons(sergeyOver35);
                            break;

                        case 5:
                            var personsInOdesa = from person in persons where person.City == "Odesa" select person;
                            PrintPersons(personsInOdesa);
                            break;

                        case 6:
                            var ukrainianEmployeesNotInOdesa = from employee in employees
                                                               where departments.Any(d => d.Id == employee.DepId && d.Country == "Ukraine" && d.City != "Odesa")
                                                               select new { employee.FirstName, employee.LastName };
                            PrintNamesAndLastNames(ukrainianEmployeesNotInOdesa);
                            break;

                        case 7:
                            var uniqueCountries = (from department in departments select department.Country).Distinct();
                            PrintStrings(uniqueCountries);
                            break;

                        case 8:
                            var employeesOver25 = (from employee in employees where employee.Age > 25 select employee).Take(3);
                            PrintEmployees(employeesOver25);
                            break;

                        case 9:
                            var kievStudentsOver23 = from employee in employees
                                                     where employee.DepId == 2 && employee.Age > 23
                                                     select new { employee.FirstName, employee.LastName, employee.Age };
                            PrintNamesAndLastNames(kievStudentsOver23);
                            break;

                        case 10:

                            var ukrainianEmployeesNamesSorted = (from employee in employees where departments.Any(d => d.Id == employee.DepId && d.Country == "Ukraine")orderby employee.FirstName, employee.LastName select employee).ToList();
                            PrintEmployees(ukrainianEmployeesNamesSorted);
                            break;

                        case 11:
                            var employeesSortedByAgeDescending = from employee in employees
                                                                 orderby employee.Age descending
                                                                 select new { employee.Id, employee.FirstName, employee.LastName, employee.Age };
                            PrintSortedEmployees(employeesSortedByAgeDescending);
                            break;

                        case 12:
                            var ageGroups = from employee in employees
                                            group employee by employee.Age into groupedEmployees
                                            select new { Age = groupedEmployees.Key, Count = groupedEmployees.Count() };

                            foreach (var group in ageGroups)
                            {
                                Console.WriteLine($"Age: {group.Age}, Count: {group.Count}");
                            }
                            break;

                        case 13:
                            var mobileGoodsOver1000 = from good in goods1 where good.Category == "Mobile" && good.Price > 1000 select good;
                            PrintGoods(mobileGoodsOver1000);
                            break;

                        case 14:
                            var nonKitchenGoodsOver1000 = from good in goods1
                                                          where good.Category != "Kitchen" && good.Price > 1000
                                                          select new { good.Title, good.Price };
                            PrintGoodsWithTitleAndPrice(nonKitchenGoodsOver1000);
                            break;

                        case 15:
                            var averagePrice = (from good in goods1 select good.Price).Average();
                            Console.WriteLine($"Average Price: {averagePrice}");
                            break;

                        case 16:
                            var distinctCategories = goods1.Select(good => good.Category).Distinct();
                            PrintStrings(distinctCategories);
                            break;

                        case 17:
                            var goodsOrderedByName = from good in goods1 orderby good.Title select good;
                            PrintGoods(goodsOrderedByName);
                            break;

                        case 18:
                            var totalCarMobileGoods = (from good in goods1
                                                       where good.Category == "Car" || good.Category == "Mobile"
                                                       select good).Count();
                            Console.WriteLine($"Total Car and Mobile Goods: {totalCarMobileGoods}");
                            break;

                        case 19:
                            var categoryCounts = from good in goods1
                                                 group good by good.Category into groupedGoods
                                                 select new { Category = groupedGoods.Key, Count = groupedGoods.Count() };
                            PrintCategoryCounts(categoryCounts);
                            break;
                        case 0:
                            return;

                        default:
                            Console.WriteLine("Something went wrong.");
                            break;
                    }
                    Console.ReadLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        static void PrintPersons(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
            }
        }

        static void PrintNames(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }
        }

        static void PrintNamesAndLastNames(IEnumerable<dynamic> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.FirstName}, Last Name: {employee.LastName}");
            }
        }

        static void PrintStrings(IEnumerable<string> strings)
        {
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }

        static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.FirstName}, Last Name: {employee.LastName}, Age: {employee.Age}");
            }
        }

        static void PrintSortedEmployees(IEnumerable<dynamic> sortedEmployees)
        {
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}");
            }
        }

        static void PrintGoods(IEnumerable<Good> goods)
        {
            foreach (var good in goods)
            {
                Console.WriteLine($"Id: {good.Id}, Title: {good.Title}, Price: {good.Price}, Category: {good.Category}");
            }
        }

        static void PrintCategoryCounts(IEnumerable<dynamic> categoryCounts)
        {
            foreach (var count in categoryCounts)
            {
                Console.WriteLine($"Category: {count.Category}, Count: {count.Count}");
            }
        }

        static void PrintGoodsWithTitleAndPrice(IEnumerable<object> goods)
        {
            foreach (var item in goods)
            {
                var dynamicItem = (dynamic)item;
                Console.WriteLine($"Title: {dynamicItem.Title}, Price: {dynamicItem.Price}");
            }
        }

        static void PrintTitlesAndPrices(IEnumerable<Good> goods)
        {
            foreach (var good in goods)
            {
                Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
            }
        }


    }





}

