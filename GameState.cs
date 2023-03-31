using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuizGame
{
    public class GameState
    {
        public int CorrectAnswers { get; set; }

        public int Lives { get; set; }

        public int TotalLives { get; set; }
        public int QuestionNum { get; set; }


        public GameState()
        {
            CorrectAnswers = 0;
            Lives = 3;
            TotalLives = 3;
            QuestionNum = 1;
        }

    }
}
