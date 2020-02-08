using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed;

    public float thrust = 1.0f;
    public Rigidbody rb;
    public float jumpForce;
    public float airThrust;
    private bool ContactAirWall = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ContactAirWall == false)
        {
 if (Input.GetAxis("Vertical") > 0)
        {
            //transform.Translate(new Vector3 (0,0,movementSpeed*Time.deltaTime));

            rb.AddForce(airThrust, 0, 0, ForceMode.Impulse);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            //transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime));

            rb.AddForce(-airThrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(0, 0, -airThrust, ForceMode.Impulse);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(0, 0, +airThrust, ForceMode.Impulse);
        }
        }
       

    }


    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("ground") && Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if (collisionInfo.gameObject.CompareTag("ground")){
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



    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AirWall"))
        {
            ContactAirWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("AirWall"))
        {
            ContactAirWall = false;
        }
    }
}
