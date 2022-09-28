namespace Lecture.Farming
{
    public class Cow : FarmAnimal, Isellable
    {
        public decimal Price { get; }
        public Cow() : base("Cow", "moo")
        {
            Price = 1500;
        }
    }
}
