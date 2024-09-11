using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = transform.position + new Vector3(-5 * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = transform.position + new Vector3(5 * Time.deltaTime, 0, 0);
        }
    }
}
