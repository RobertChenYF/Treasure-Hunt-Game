using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed;

    public float thrust = 1.0f;
    public Rigidbody rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            //transform.Translate(new Vector3 (0,0,movementSpeed*Time.deltaTime));

            rb.AddForce(thrust, 0, 0, ForceMode.Impulse);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            //transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime));

            rb.AddForce(-thrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(0, 0, -thrust, ForceMode.Impulse);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(0, 0, +thrust, ForceMode.Impulse);
        }



    }


    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("ground") && Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        

    }

}
