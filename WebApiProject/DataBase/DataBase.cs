using WebApiProject.Models;

namespace WebApiProject.DataBase;

public class DataBase
{
    public static List<Animal> Animals = new()
    {
        new Animal{Id = 1,Name = "Reksio",Type = "Dog",Mass = 4.5,FurColor = "Black"},
        new Animal{Id = 2, Name = "Whiskers", Type = "Cat", Mass = 3.2, FurColor = "White"},
        new Animal{Id = 3, Name = "Buddy", Type = "Dog", Mass = 7.8, FurColor = "Brown"},
        new Animal{Id = 4, Name = "Mittens", Type = "Cat", Mass = 2.7, FurColor = "Gray"},
        new Animal{Id = 5, Name = "Daisy", Type = "Dog", Mass = 6.1, FurColor = "Golden"},
    };
}