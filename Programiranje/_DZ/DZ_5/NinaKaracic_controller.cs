using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField]
    float speed;
    float horizontal;
    float vertical;
    float jumpS = 6f;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if(JumpCheck())
        {
            GetComponent<Rigidbody>().AddForce(jumpS * transform.up, ForceMode.Impulse);
        }
    }

    bool JumpCheck()
    {
        Ray ray = new Ray(transform.position, transform.up * -1);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, transform.localScale.y + 0.2f))
        {
            return true;
        }

        return false;
    }
}
