using Unity.Cinemachine;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineCamera FreeLookCamera;

    void Update()
    {
        transform.forward = FreeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
