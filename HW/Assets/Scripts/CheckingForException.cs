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
                throw new GameDesignerException("������� �����", tag, other.tag);
            }
            catch(GameDesignerException e)
            {
                Debug.LogWarning($"������ {e.TagPlayer} {e.Message} {e.TagLvlObject}");
            }
        }
    }
}