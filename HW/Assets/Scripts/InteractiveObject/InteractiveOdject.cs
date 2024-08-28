using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        protected Color _color;
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void Start()
        {
            Action();
        }

        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
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
    }
}