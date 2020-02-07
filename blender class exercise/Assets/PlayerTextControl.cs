using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextControl : MonoBehaviour
{

    private float PlateTimer = 0;
    private float PlateTargetTimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlateTimer >= PlateTargetTimer)
        {
            Debug.Log("Win");
        }
    }


    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Plate"))
        {
            PlateTimer += Time.deltaTime;
        }

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            PlateTimer = 0;
        }
    }


}
