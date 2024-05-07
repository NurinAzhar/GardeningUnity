using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject gardenBase;

    private Vector3 currentPos;
    private float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        gardenBase = GameObject.Find("Base");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            transform.RotateAround(gardenBase.transform.position, Vector3.down, speed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.RotateAround(gardenBase.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        
    }
}
