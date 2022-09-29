namespace Lecture.Farming
{
    public class Pig : FarmAnimal, ISellable
    {
        public decimal Price { get; }


        public override string Eat()
        {
            
            {
                return "yum yum, garbage!";
            }
        }
        public Pig() : base("Pig", "oink")
        {
            Price = 300;
        }
    }
}
