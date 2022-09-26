namespace Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        //  For 90% or greater, it returns "A"
        //- For 80-89%, it returns "B"
        // - For 70-79%, it returns "C"
        //  - For 60-69%, it returns "D"
        //  - Otherwise, it returns "F"
        public string SubmitterName { get; private set; }

        public string LetterGrade
        {
            get
            {
                double grade =  ((double)(EarnedMarks) / (double)(PossibleMarks) * 100);
                if (grade >= 90)
                { return "A"; }
                if (grade >= 80 && grade <= 89)
                { return "B"; }
                if (grade >= 70 && grade <= 79)
                { return "C"; }
                if (grade >= 60 && grade <= 69)
                { return "D"; }

                {
                    return "F";
                }
            }

        }


        public HomeworkAssignment(int totalScore, string theirName)
        {
            this.PossibleMarks = totalScore;
            this.SubmitterName = theirName;
        }
    }
}
               
            
     














