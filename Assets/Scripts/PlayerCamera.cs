using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float CameraSpeed = 3f;
    public Camera PCamera;
    public Transform Body;

    private Vector2 _cameraRotation = Vector2.zero;
    void Update()
    {
        _cameraRotation.y += Input.GetAxis("Mouse X");
        _cameraRotation.x -= Input.GetAxis("Mouse Y");
        Vector2 rotation = _cameraRotation * CameraSpeed;
        Body.eulerAngles = new Vector2(0, rotation.y);
        PCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
    }
}
