using UnityEngine.UI;
using UnityEngine;

namespace Geekbrains
{
    public sealed class DisplayBonuses
    {
        private Text _text;
        private int _sum = 0;
        public DisplayBonuses(Text text)
        {
            _text = text;
        }

        public void PlusBonus(int value)
        {
            _sum += value;
            Display(_sum);
        }

        public void MinusBonus(int value)
        {
            _sum -= value;
            Display(_sum);
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }
    }
}