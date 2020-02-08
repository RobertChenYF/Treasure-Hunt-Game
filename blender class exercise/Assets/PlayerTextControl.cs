using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTextControl : MonoBehaviour
{

    private float PlateTimer = 0;
    private float PlateTargetTimer = 2;
    public Collider withinPlate;
    private bool standStill;
    private float xRotation;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlateTimer >= PlateTargetTimer)
        {
            textMeshProUGUI.text = "You win the Game!";
        }

        if (withinPlate.bounds.Contains(transform.position) == false || standStill == false)
        {
            PlateTimer = 0;
            Debug.Log("Timer 0 1");
        }
        if (xRotation == transform.rotation.x && transform.eulerAngles.x >267 && transform.eulerAngles.x < 273)
        {
            standStill = true;
            Debug.Log("standing still");
        }
        else
        {
            standStill = false;
        }

        if (withinPlate.bounds.Contains(transform.position) && standStill)
        {
            PlateTimer += Time.deltaTime;
            Debug.Log("add time");
        }
        xRotation = transform.rotation.x;
    }


    void OnCollisionStay(Collision collisionInfo)
    {
       

        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plate")  )
        {
            PlateTimer = 0;
            Debug.Log("Timer 0 2");
        }
    }


}
