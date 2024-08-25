using System;
using Object = UnityEngine.Object; 

namespace Geekbrains
{
    public sealed class TestListBonuses<T>
    {
        private GoodBonus[] _goodBonuses;
        private BadBonus[] _badBonuses;

        private T[] _testListBonuses;

        public TestListBonuses()
        {
            _goodBonuses = Object.FindObjectsOfType<GoodBonus>();
            Array.Sort(_goodBonuses);

            _badBonuses = Object.FindObjectsOfType<BadBonus>();
            Array.Sort(_badBonuses);
        }

        public T this [int index]
        {
            get => _testListBonuses[index];
            set => _testListBonuses[index] = value;
        }

        public int Count => _testListBonuses.Length;
    }
}