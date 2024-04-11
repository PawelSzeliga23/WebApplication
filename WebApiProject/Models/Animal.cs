namespace WebApiProject.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Mass { get; set; }
    public string FurColor { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Animal other = (Animal)obj;
        return Id == other.Id && Name == other.Name && Type == other.Type && Mass.CompareTo(other.Mass) == 0 &&
               FurColor == other.FurColor;
    }
}