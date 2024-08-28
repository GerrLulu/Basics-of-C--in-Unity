using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private float _sensitiveX = 7.0f;
        [SerializeField] private float _sensitiveZ = 7.0f;
        [SerializeField] private float _max = 10.0f;
        [SerializeField] private float _min = -10.0f;

        private float _rotationX;
        private float _rotationZ;


        protected void RotateLevel()
        {
            _rotationX += Input.GetAxis("Mouse Y") * _sensitiveX;
            _rotationX = Mathf.Clamp(_rotationX, _min, _max);

            _rotationZ += Input.GetAxis("Mouse X") * _sensitiveZ;
            _rotationZ = Mathf.Clamp(_rotationZ, _min, _max);

            transform.localEulerAngles = new Vector3(-_rotationX, 0, _rotationZ);
        }
    }
}