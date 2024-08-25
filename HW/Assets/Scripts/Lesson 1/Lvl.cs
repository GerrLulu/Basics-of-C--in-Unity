using UnityEngine;

namespace Geekbrains
{
    public class Lvl : MonoBehaviour
    {
        public float sensitiveX = 7.0f;
        public float sensitiveZ = 7.0f;
        public float min = -10.0f;
        public float max = 10.0f;
        private float rotationX;
        private float rotationZ;

        protected void RotateLvl()
        {
            rotationX += Input.GetAxis("Mouse Y") * sensitiveX;
            rotationX = Mathf.Clamp(rotationX, min, max);
            rotationZ += Input.GetAxis("Mouse X") * sensitiveZ;
            rotationZ = Mathf.Clamp(rotationZ, min, max);

            transform.localEulerAngles = new Vector3(-rotationX, 0, rotationZ);
        }
    }
}