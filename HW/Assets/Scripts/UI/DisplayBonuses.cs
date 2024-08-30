using UnityEngine.UI;

namespace UI
{
    public sealed class DisplayBonuses
    {
        private int _sum = 0;
        private Text _text;


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