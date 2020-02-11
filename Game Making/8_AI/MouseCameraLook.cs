using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraLook : MonoBehaviour
{
    //SKRIPTA NA KAMERI

    [SerializeField]
    float sensitivity;
    [SerializeField]
    float smoothing;
    [SerializeField]
    GameObject player;

    Vector2 mouseLook;
    Vector2 smoothV;

    private void Start()
    {
        player = this.transform.parent.gameObject;
    }

    private void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
        //Dajemo vrijednost pogledu kamere
        mouseLook += smoothV;

        //Ako je mouse x pozitivan onda imamo efekt reverse kontrole
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //DZ NEMOŽEŠ KAMERU OKRETATI 360° 
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
