using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        protected Color _color;

        public bool IsInteractable { get; } = true;


        private void Start()
        {
            Action();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (IsInteractable || collision.collider.tag == "Player")
            {
                Interaction();
                Destroy(gameObject);
            }
            return;
        }


        protected abstract void Interaction();

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}