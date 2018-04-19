using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class LetterClass
    {
        string letterName;
        string letterImageName;
        Question1Class question1;
        Question2Class question2;

        public LetterClass(string letName, string letimagename,
            string quest1, string questq1ImgName, string q1an1, string q1an2, string q1an3, string q1an4, string q1cor,
            string quest2, string q2an1Image, string q2an2Image, string q2an3Image, string q2an4Image,
            string q2corImage)
        {
            letterName = letName;
            letterImageName = letimagename;
            question1 = new Question1Class(quest1, questq1ImgName, q1an1, q1an2, q1an3, q1an4, q1cor);
            question2 = new Question2Class(quest2, q2an1Image, q2an2Image, q2an3Image, q2an4Image, q2corImage);
        }

        //Setters
        public void SetLetterName(string str)
        {
            letterName = str;
        }

        public void SetLetterImageName(string str)
        {
            letterImageName = str;
        }

        //Getters
        public string GetLetterName()
        {
            return letterName;
        }

        public string GetLetterImageName()
        {
            return letterImageName;
        }
    }

}
