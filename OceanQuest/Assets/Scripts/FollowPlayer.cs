using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform followPlayer;
    [SerializeField] public float rotationSpeed = 10f;
    [SerializeField] private float bottomClamp = -40f;
    [SerializeField] private float topClamp = 70f;

    private float cinemachineTargatePitch;
    private float cinemachineTargateYaw;

    private void CameraLogic()
    {
        float mouseX = GetMouseInput("Mouse X");
        float mouseY = GetMouseInput("Mouse Y");
    }



    private float GetMouseInput(string axis)
    {
        return Input.GetAxis(axis) * rotationSpeed * Time.deltaTime;
    }
}
