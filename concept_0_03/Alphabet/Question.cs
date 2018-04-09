using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class Question
    {
        string question;
        string questionImageName;
        string answer1;
        string answer2;
        string answer3;
        string answer4;
        string correctAnswer;

        List<Alphabet.JapChar> questionSet = new List<Alphabet.JapChar> { };

        int rng;

        private int Rng(int count)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int r = rand.Next(0, count);
            return r;
        }

        public bool CheckAns(string result)
        {
            if (result == correctAnswer) { return true; }
            else { return false; }
        }

        public Question(List<Alphabet.JapChar> currentSet)
        {

            int setCount = currentSet.Count;

            rng = Rng(setCount);
            questionSet.Add(currentSet[rng]);

            rng = Rng(setCount);
            questionSet.Add(currentSet[rng]);

            rng = Rng(setCount);
            questionSet.Add(currentSet[rng]);

            rng = Rng(setCount);
            questionSet.Add(currentSet[rng]);

            question = questionSet[0].Japa;
            answer1 = questionSet[0].Roma;
            answer2 = questionSet[1].Roma;
            answer3 = questionSet[2].Roma;
            answer4 = questionSet[3].Roma;
            correctAnswer = questionSet[0].Roma;

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