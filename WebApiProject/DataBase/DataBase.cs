using WebApiProject.Models;

namespace WebApiProject.DataBase;

public class DataBase
{
    public static List<Animal> Animals = new()
    {
        new Animal { Id = 1, Name = "Reksio", Type = "Dog", Mass = 4.5, FurColor = "Black" },
        new Animal { Id = 2, Name = "Whiskers", Type = "Cat", Mass = 3.2, FurColor = "White" },
        new Animal { Id = 3, Name = "Buddy", Type = "Dog", Mass = 7.8, FurColor = "Brown" },
        new Animal { Id = 4, Name = "Mittens", Type = "Cat", Mass = 2.7, FurColor = "Gray" },
        new Animal { Id = 5, Name = "Daisy", Type = "Dog", Mass = 6.1, FurColor = "Golden" },
    };

    public static List<Appointment> Appointments = new()
    {
        new Appointment
        {
            Date = new DateTime(2024, 4, 11), Animal = Animals[0], Description = "Annual checkup", Price = 50.0
        },
        new Appointment
        {
            Date = new DateTime(2024, 4, 12), Animal = Animals[1], Description = "Vaccination", Price = 35.0
        },
        new Appointment
        {
            Date = new DateTime(2024, 4, 13), Animal = Animals[2], Description = "Spaying surgery", Price = 120.0
        },
        new Appointment
        {
            Date = new DateTime(2024, 4, 14), Animal = Animals[3], Description = "Dental cleaning", Price = 70.0
        },
        new Appointment
        {
            Date = new DateTime(2024, 4, 15), Animal = Animals[4], Description = "Flea treatment", Price = 25.0
        }
    };
}