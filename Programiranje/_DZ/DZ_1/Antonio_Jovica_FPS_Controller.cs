using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antonio_Jovica_FPS_Controller_v1 : MonoBehaviour
{
    public float walk = 0.3f;
    float run = 0.6f;
    public Transform playerBody;
    bool isOnGround;

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            playerBody.localPosition += new Vector3(0, 0, walk);      
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBody.localPosition -= new Vector3(0, 0, walk);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            playerBody.localPosition -= new Vector3(walk, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerBody.localPosition += new Vector3(walk, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerBody.localPosition += new Vector3(0, 5f, 0);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walk += run;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            walk -= run;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        isOnGround = true;
    }
}
