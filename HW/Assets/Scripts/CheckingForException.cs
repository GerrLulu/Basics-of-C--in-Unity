using UnityEngine;

namespace Geekbrains
{
    public class CheckingForException : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            try
            {
                if (!other.CompareTag("Level"))
                    return;
                throw new GameDesignerException("перешел через", tag, other.tag);
            }
            catch(GameDesignerException e)
            {
                Debug.LogWarning($"Объект {e.TagPlayer} {e.Message} {e.TagLvlObject}");
            }
        }
    }
}