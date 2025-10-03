using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0);
    [SerializeField] private float maxVerticalLook = 40f;
    [SerializeField] private float minVerticalLook = 10f;
    private Vector3 lookAngles;
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector2 lookDelta = new Vector2(mouseX, mouseY);
        lookAngles += new Vector3(-lookDelta.y, lookDelta.x, 0);
        lookAngles.x = Mathf.Clamp(lookAngles.x, minVerticalLook, maxVerticalLook);

        Quaternion lookRot = Quaternion.Euler(lookAngles.x, lookAngles.y, 0f);
        Vector3 pos = Player.position + lookRot * offset;
        transform.SetPositionAndRotation(pos, lookRot);
    }
}
