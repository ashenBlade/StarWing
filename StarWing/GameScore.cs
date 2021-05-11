using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWing
{
    class AddGameScore
    {
        private int _currentScore;
        private int _addScore;

        public AddGameScore(int score, int addScore)
        {
            _currentScore = score;
            _addScore = addScore;
        }

        public int Score
        {
            get
            {
                return _currentScore;
            }
        }

        public int AddScore
        {
            get
            {
                return _addScore;
            }
        }
    }
}
