using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCouroutines : MonoBehaviour
{
    public GameObject pest;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // Handle deactivation of spawning/active pests 
        GetComponentInParent<PestGenerator>().StopAllCoroutines();

        if (pest.activeInHierarchy)
        {
            pest.GetComponent<PestBehaviour>().StopAllCoroutines();
            pest.SetActive(false);
        }
    }
}
