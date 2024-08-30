using Interface;
using System.Collections;
using UnityEngine;
using static UnityEngine.Debug;

namespace PlayerNS
{
    public sealed class PlayerBall : Player, ISpeedChanger
    {
        private float _boost = 10.0f;
        private float _slow = 3.0f;


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
            Speed = Speed * _boost;
            Log("Скорость увеличелась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed / _boost;
            Log("Скорость вернулась в норму");
        }

        private IEnumerator SlowSpeed()
        {
            Speed = Speed / _slow;
            Log("Скорость уменьшилась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed * _slow;
            Log("Скорость вернулась в норму");
        }
    }
}