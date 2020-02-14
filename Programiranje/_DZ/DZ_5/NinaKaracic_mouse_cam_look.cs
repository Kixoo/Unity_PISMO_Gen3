using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_cam_look : MonoBehaviour
{
    [SerializeField]
    float sensitivity;

    [SerializeField]
    float smoothing;

    [SerializeField]
    GameObject Player;

    Vector2 mouseLook;
    Vector2 smoothV;

    float SpeedH = 10f;
    float SpeedV = 10f;

    private float yaw = 0f;
    private float pitch = 0f;
    private float minPitch = -30f;
    private float maxPitch = 60f;

    private void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    private void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);

        mouseLook += smoothV;  //dajemo vrijednost pogledu kamere

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);

        CameraRotate();
    }

    void CameraRotate()
    {
        yaw += Input.GetAxis("Mouse X") * SpeedH;
        pitch -= Input.GetAxis("Mouse Y") * SpeedV;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
