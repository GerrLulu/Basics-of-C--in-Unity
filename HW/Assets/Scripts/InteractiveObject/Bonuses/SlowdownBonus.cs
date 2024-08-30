using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractiveObjectNS.Bonuses
{
    public sealed class SlowdownBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        private float _lengthFly;
        private float _speedRotation;

        public event CaughtPlayerChange CaughtPlayer;
        public delegate void CaughtPlayerChange();


        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }


        protected override void Interaction()
        {
            CaughtPlayer?.Invoke();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            return Instantiate(gameObject, new Vector3(-6.79f, 0.6f, 0.53f),
                transform.rotation, transform.parent);
        }
    }
}