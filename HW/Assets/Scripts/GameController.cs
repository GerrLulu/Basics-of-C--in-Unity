using InteractiveObjectNS;
using InteractiveObjectNS.Bonuses;
using Interface;
using PlayerNS;
using UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private InteractiveObject[] _interactiveObjects;
        public Text _text;
        private DisplayBonuses _displayBonuses;
        public PlayerBall _playerBall;

        private void Awake()
        {
            FindObjectOfType<GoodBonus>().Clone();
            FindObjectOfType<BadBonus>().Clone();
            FindObjectOfType<SpeedBonus>().Clone();
            FindObjectOfType<SlowdownBonus>().Clone();

            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _displayBonuses = new DisplayBonuses(_text);
            //_playerBall = FindObjectOfType<PlayerBall>();
            foreach(var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += _displayBonuses.MinusBonus;
                }
                else if (o is GoodBonus goodBonus)
                {
                    goodBonus.CaughtPlayer += _displayBonuses.PlusBonus;
                }
                else if (o is SpeedBonus speeBonus)
                {
                    speeBonus.CaughtPlayer += _playerBall.Booster;
                }
                else if (o is SlowdownBonus slowdownBonus)
                {
                    slowdownBonus.CaughtPlayer += _playerBall.Slowdowner;
                }
            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= _displayBonuses.MinusBonus;
                }
                else if (o is GoodBonus goodBonus)
                {
                    goodBonus.CaughtPlayer -= _displayBonuses.PlusBonus;
                }
                else if (o is SpeedBonus speeBonus)
                {
                    speeBonus.CaughtPlayer -= _playerBall.Booster;
                }
                else if (o is SlowdownBonus slowdownBonus)
                {
                    slowdownBonus.CaughtPlayer -= _playerBall.Slowdowner;
                }
                Destroy(o.gameObject);
            }
        }
    }
}