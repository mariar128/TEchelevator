namespace Lecture.Farming
{
    public class Pig : FarmAnimal, Isellable // inherits from FarmAnimal, *and* implements Isellables
    {
public decimal Price { get; }
        public Pig() : base("Pig", "oink")
        {
            Price = 60;
        }
    }
}
