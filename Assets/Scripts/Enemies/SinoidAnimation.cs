using UnityEngine;

namespace Shmup.Enemies
{
    public class SinoidAnimation : MonoBehaviour
    {
        [SerializeField] private Transform rotationPart;
        [SerializeField] private float rotationSpeed = 5;

        private void Update()
        {
            Vector3 angles = rotationPart.rotation.eulerAngles + new Vector3(0, 0, rotationSpeed * Time.deltaTime);
            Quaternion rot = Quaternion.Euler(angles);
            rotationPart.rotation = rot;
        }
    }
}