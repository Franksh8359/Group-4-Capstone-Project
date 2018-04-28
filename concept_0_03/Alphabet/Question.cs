using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class Question
    {
        private string question;
        private string questionImageName;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private string correctAnswer;

        private List<Alphabet.JapChar> questionSet = new List<Alphabet.JapChar> { };
        private List<Alphabet.JapChar> finalSet = new List<Alphabet.JapChar> { };

        private int rng;

        public Question()
        {
            question = "";
            questionImageName = "";
            answer1 = "";
            answer2 = "";
            answer3 = "";
            answer4 = "";
            correctAnswer = "";
        }

        public Question(List<Alphabet.JapChar> currentSet)
        {
            List<int> rngList = new List<int> { };

            //PICK FOUR NUMBERS AT RANDOM (UP TO THE COUNT OF THE MASTER LIST) AND ADD THEM TO THEIR OWN LIST
            for (int i = 0; i < 4;)
            {
                rng = Rng(currentSet.Count);
                if (!rngList.Contains(rng)) { rngList.Add(rng); i++; }
            }

            //FOR EACH OF THE FOUR NUMBERS, ADD THE CHARACTER AT THAT INDEX OF THE MASTER LIST TO THE QUESTIONSET
            foreach (int i in rngList) { questionSet.Add(currentSet[i]); }

            //CHOOSE A QUESTION FORMAT (coin flip)
            int format = Rng(2);

            //SET THE QUESTION AND ANSWER TO THE FIRST IN THE QUESTIONSET
            if (format == 0) //(if the coin flip was heads, set ques in Japanese format)
            {
                question = questionSet[0].Japa;
                correctAnswer = questionSet[0].Roma;
            }
            else //(if the coin flip was tails, set ques in English format)
            {
                question = questionSet[0].Roma;
                correctAnswer = questionSet[0].Japa;
            }

            //SHUFFLE THE QUESTIONSET
            int n = questionSet.Count;
            while (n > 1)
            {
                n--;
                int k = Rng(n + 1);
                Alphabet.JapChar value = questionSet[k];
                questionSet[k] = questionSet[n];
                questionSet[n] = value;
            }

            //DISTRIBUTE POSSIBLE ANSWERS BASED ON SHUFFLED SET (based on format)
            if (format == 0)
            {
                answer1 = questionSet[0].Roma;
                answer2 = questionSet[1].Roma;
                answer3 = questionSet[2].Roma;
                answer4 = questionSet[3].Roma;
            }
            else
            {
                answer1 = questionSet[0].Japa;
                answer2 = questionSet[1].Japa;
                answer3 = questionSet[2].Japa;
                answer4 = questionSet[3].Japa;
            }

        }

        private int Rng(int count)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int r = rand.Next(count);
            return r;
        }

        public bool CheckAns(string result)
        {
            if (result == correctAnswer) { return true; }
            else { return false; }
        }

        private List<Alphabet.JapChar> CreateQuestionSet(List<Alphabet.JapChar> currentSet)
        {
            

            return questionSet;
        }

        public string Quest { get { return question; } set { question = value; } }
        public string QuestImgName { get { return questionImageName; } set { questionImageName = value; } }
        public string Ans1 { get { return answer1; } set { answer1 = value; } }
        public string Ans2 { get { return answer2; } set { answer2 = value; } }
        public string Ans3 { get { return answer3; } set { answer3 = value; } }
        public string Ans4 { get { return answer4; } set { answer4 = value; } }
        public string CorrectAns { get { return correctAnswer; } set { correctAnswer = value; } }

    }
}