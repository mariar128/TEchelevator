namespace Lecture.Farming
{
    public class Cat : FarmAnimal
    { 

        public Cat() : base("Cat", "meow")
        {
        
        }
        public override string Eat()
        {
            return "yum yum, cat food!";
        }
       public override string Sound
        {
            get
            {
                return "meow";
            }
        }
    }
}
