using System.Collections;
using UnityEngine;
using static UnityEngine.Debug;

namespace Geekbrains
{
    public sealed class PlayerBall : Player, ISpeedChanger
    {
        private float boost = 10.0f;
        private float slow = 3.0f;

        private void FixedUpdate()
        {
            Move();
        }

        public void Booster()
        {
            StartCoroutine(BoostSpeed());
        }

        public void Slowdowner()
        {
            StartCoroutine(SlowSpeed());
        }

        private IEnumerator BoostSpeed()
        {
            Speed = Speed * boost;
            Log("Скорость увеличелась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed / boost;
            Log("Скорость вернулась в норму");
        }

        private IEnumerator SlowSpeed()
        {
            Speed = Speed / slow;
            Log("Скорость уменьшилась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed * slow;
            Log("Скорость вернулась в норму");
        }
    }
}