namespace Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; 
        }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPieceOfFruit)
        {
            this.PiecesOfFruitLeft = startingPieceOfFruit;
            this.TypeOfFruit = typeOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if (PiecesOfFruitLeft >= numberOfPiecesToRemove)
            {
                PiecesOfFruitLeft -= numberOfPiecesToRemove;
                return true;
            }
            if(PiecesOfFruitLeft > 0)
            {
                return false;
            }
            return false;
            
           
        }
    }
}
