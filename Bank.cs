using System;
using System.Collections.Generic;

namespace Heist
{
    public class Bank
    {
        private int _difficulty = 100;
        public int Luck { get; set; }
        public void BankDifficulty(int difficulty)
        {
            _difficulty = difficulty;
        }
        public int GetDifficulty()
        {
            return _difficulty;
        }
        public void GetLuck()
        {
            Luck = new Random().Next(-10, 11);
        }
    }
}