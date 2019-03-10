using System;

namespace ConsoleApp2
{
    public class User
    {
        public string name;
        public string firstName;
        public string lastName;
        public string pronoun;

        public int daysUntilBirthday;
        public int age;
        public DateTime birthDate;
        public Gender gender;

        public enum Gender
        {
            Male,
            Female
        }
    }
}
