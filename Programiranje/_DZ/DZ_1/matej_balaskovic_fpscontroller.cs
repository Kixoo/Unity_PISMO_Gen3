using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matej_balaskovic_fpscontroller : MonoBehaviour
{
    //ko procita gay ahaha xd


    [Header("Defaultovi")]
    public float playerDefaultHeight = 2; 
    //visina igraca, potrebno za crouch
    public float playerDefaultPos = 2; 
    // isto sta i gor

    //!!!!!!na kraju ih uopce nisam mogo iskoristit jer... duga prica

    float xScale;
    float yScale;
    float zScale;
    float xPos;
    float yPos;
    float zPos;
    //^da uzme sve pre-setane postavke za transform

    //!!!!!!ipak se ne koristi jer je gay, dole ima iskomentiran stari kod

        [Header("Kolicine kretanja")]
    public float speedBase; 
    //definira kolko ce se pomac u z (napred/nazad)
    //0.1 je ok
    public float speedStrafe; 
    //definira kolko ce se pomac u x (ljevo/desno)
    //0.1 isto ok
    public float jumpLength; 
    //definira kolko ce se pomac u y (odnosno skok)
    //1 ok
    public float crouchScale = 0.5f;
    public float crouchPos = 0.5f;
    //varijable za crouch, position bi ga sam gurno pod pod pa sam stavio i scale
    //jer bi teoretski character model preso u drugu animaciju gdje je manji
    //to sto su isti je slucajnost :)

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) //naprjed
        {
            transform.localPosition += new Vector3(0, 0, speedBase);
        }
        if (Input.GetKey(KeyCode.S)) //nazad
        {
            transform.localPosition -= new Vector3(0, 0, speedBase);
        }
        if (Input.GetKey(KeyCode.D)) //desno
        {
            transform.localPosition += new Vector3(speedStrafe, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) //ljevo
        {
            transform.localPosition -= new Vector3(speedStrafe, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space)) //jump
        {
            transform.localPosition += new Vector3(0, jumpLength, 0);
            //tjeo sam stavit neki cooldown al neznam kak iskoristit wait/sleep jer me jebe za metodu
            //a tjeo sam cooldown jer tehnicki mos odletit na svemir ak spamas space
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale -= new Vector3(0, crouchScale, 0);
            transform.localPosition -= new Vector3(0, crouchPos, 0);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            transform.localScale += new Vector3(0, playerDefaultHeight, 0);
            transform.localPosition += new Vector3(0, playerDefaultPos, 0);
        }
    }
}

//ovo djubre od koda je sve sjebalo
//proceed with caution

//private void FixedUpdate()
//{
//    xScale = transform.localPosition.x;
//    yScale = transform.localPosition.y;
//    zScale = transform.localPosition.z;
//    xPos = transform.localPosition.x;
//    yPos = transform.localPosition.y;
//    zPos = transform.localPosition.z;
//    //el trebam uopce objasnit

//    if (Input.GetKey(KeyCode.W)) //naprjed
//    {
//        transform.localPosition += new Vector3(xPos, yPos, speedBase);
//    }
//    if (Input.GetKey(KeyCode.S)) //nazad
//    {
//        transform.localPosition -= new Vector3(xPos, yPos, speedBase);
//    }
//    if (Input.GetKey(KeyCode.D)) //desno
//    {
//        transform.localPosition += new Vector3(speedStrafe, yPos, zPos);
//    }
//    if (Input.GetKey(KeyCode.A)) //ljevo
//    {
//        transform.localPosition -= new Vector3(speedStrafe, yPos, zPos);
//    }
//    if (Input.GetKeyDown(KeyCode.Space)) //jump
//    {
//        transform.localPosition += new Vector3(xPos, jumpLength, zPos);
//        //tjeo sam stavit neki cooldown al neznam kak iskoristit wait/sleep jer me jebe za metodu
//        //a tjeo sam cooldown jer tehnicki mos odletit na svemir ak spamas space
//    }
//    if (Input.GetKeyDown(KeyCode.C))
//    {
//        transform.localScale = new Vector3(xScale, crouchScale, zScale);
//        transform.localPosition = new Vector3(xPos, crouchPos, zPos);
//    }
//    if (Input.GetKeyUp(KeyCode.C))
//    {
//        transform.localScale = new Vector3(xScale, playerDefaultHeight, zScale);
//        transform.localPosition = new Vector3(xPos, playerDefaultPos, zPos);
//    }
//}
