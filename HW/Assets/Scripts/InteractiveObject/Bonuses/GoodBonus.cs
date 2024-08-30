using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractiveObjectNS.Bonuses
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable, IComparable<GoodBonus>
    {
        private float _lengthFly;
        private Material _material;

        public event CaughtPlayerChange CaughtPlayer;
        public delegate void CaughtPlayerChange(int value);


        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 2.0f);
        }


        protected override void Interaction()
        {
            CaughtPlayer?.Invoke(5);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public object Clone()
        {
            return Instantiate(gameObject, new Vector3(6.77f, 0.6f, -5.38f),
                transform.rotation,transform.parent);
        }

        public int CompareTo(GoodBonus other)
        {
            return name.CompareTo(other.name);
        }
    }
}