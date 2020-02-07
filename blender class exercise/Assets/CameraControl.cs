using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float cameraHeight = 20.0f;
    

    void Update()
    {
        Vector3 pos = player.transform.position;
        //pos.z += cameraHeight;
        pos.x += -12;
        pos.y += 9;
        transform.position = pos;
    }
}
