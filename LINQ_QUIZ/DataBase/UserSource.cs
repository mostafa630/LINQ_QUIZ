using System.Collections.Generic;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.DataBase
{
    internal static class UserSource
    {
        public static readonly User Ethan = new User(
           id: 5,
           name: "Ethan",
           age: 40,
           country: "Germany",
           department: Department.IT,
           initialSalary: 15000M,
           manager: null
       );

        private static readonly User Hesham = new User(
            id: 22,
            name: "Hesham",
            age: 20,
            country: "USA",
            department: Department.IT,
            initialSalary: 7000M,
            manager: Ethan
        );

        public static readonly User Alice = new User(
            id: 1,
            name: "Alice",
            age: 30,
            country: "USA",
            department: Department.IT,
            initialSalary: 10000M,
            manager: Ethan
        );


        public static readonly User Bob = new User(
            id: 2,
            name: "Bob",
            age: 25,
            country: "UK",
            department: Department.SERVICE_GROUP,
            initialSalary: 15000M,
            manager: null
        );

        public static readonly User Charlie = new User(
            id: 3,
            name: "Charlie",
            age: 35,
            country: "Canada",
            department: Department.SERVICE_GROUP,
            initialSalary: 11000M,
            manager: Bob
        );

        public static readonly User Diana = new User(
            id: 4,
            name: "Diana",
            age: 28,
            country: "Australia",
            department: Department.HR,
            initialSalary: 9500M,
            manager: null
        );



        private static readonly List<User> Users = new()
        {
            Alice,
            Bob,
            Charlie,
            Diana,
            Ethan,
            Hesham
        };

        public static IEnumerable<User> GetAllUsers()
        {
            return Users;
        }
    }
}
