using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args) {
            Program program = new Program();
            User user = new User();
            Console.Write("Enter name first and last name: ");
            user.name = Console.ReadLine();
            program.CheckBirthday(user);
            user.daysUntilBirthday = program.DaysUntilBirthday(user.birthDate);
            user.age = program.CalculateAge(user.birthDate);
            Console.Write("Enter gender: ");
            user.gender = program.CheckGender();
            user.firstName = user.name.Split(' ')[0];
            if (user.name.Split(' ').Length > 1) {
                user.lastName = user.name.Split(' ')[1];
            } else {
                user.lastName = user.name.Split(' ')[0];
            }
            if (user.gender == User.Gender.Male) {
                user.pronoun = "Mr";
            } else {
                user.pronoun = "Mrs";
            }
            Console.WriteLine($"Hello {user.pronoun}. {user.lastName}, I see you’re currently {user.age} years old, and your birthday is {user.daysUntilBirthday} days away!");
        }

        private void CheckBirthday(User user) {
            bool completed = false;
            while (completed == false) {
                Console.Write("Enter birthdate: ");
                try {
                    user.birthDate = Convert.ToDateTime(Console.ReadLine());
                    completed = true;
                } catch {
                    completed = false;
                    Console.WriteLine("Invalid birthdate.");
                }
            }
        }

        int CalculateAge(DateTime birthdate) {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
                age--;
            return age;
        }

        int DaysUntilBirthday(DateTime birthdate) {
            DateTime today = DateTime.Today;
            DateTime next = birthdate.AddYears(today.Year - birthdate.Year);

            if (next < today)
                next = next.AddYears(1);

            return (next - today).Days;
        }
        User.Gender CheckGender() {
            bool complete = false;
            string line;
            User.Gender gender = User.Gender.Male;
            while (complete == false) {
                line = Console.ReadLine();
                if (line.ToLower() == "male" || line.ToLower() == "female") {
                    switch (line) {
                        case "male":
                            gender = User.Gender.Male;
                            complete = true;
                            break;
                        case "female":
                            gender = User.Gender.Female;
                            complete = true;
                            break;
                        default:
                            break;
                    }
                } else {
                    Console.WriteLine("Invalid gender, try again.");
                    Console.Write("Enter gender, and get it right this time: ");
                }
            }
            return gender;
        }
    }
}
