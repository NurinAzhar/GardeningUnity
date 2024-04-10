using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PestGenerator : MonoBehaviour
{
    public GameObject pest;
    public GameObject soilPos;

    public Vector3 scaledSoil = new Vector3(379.7141f, 500f, 390.2904f); //soil lifted scaling

    public float seconds;
    public Boolean soilLifted;
    public Boolean generatedTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator Spawn()
    {
        seconds = UnityEngine.Random.Range(5f, 7f);

        yield return new WaitForSeconds((int)seconds);

        pest.SetActive(true);

    }

    private void checkSoil()
    {
        if (soilPos.transform.lossyScale != scaledSoil)
        {
            soilLifted = false;

        } else
        {
            soilLifted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Keep updating to see if tree is generated in hierarchy
        generatedTree = gameObject.GetComponentInChildren<LsystemScript>().generatedTree;

        checkSoil();

        //might need to check up on these again
        if (generatedTree && !soilLifted)
        {
            if (!pest.activeInHierarchy)
            {
                StartCoroutine(Spawn());
            }

        } else
        {
            //pest.SetActive(false);
        }
    }

}
