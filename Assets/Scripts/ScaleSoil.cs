using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleSoil : MonoBehaviour
{
    public Vector3 scaledSoil = new Vector3 (379.7141f, 500f, 390.2904f);
    public Vector3 unscaledSoil;
    public Vector3 currentSoil;
    public Boolean originalSoilState = false;

    LsystemScript lScript;

    public Boolean generatedTreeExists;

    //private void Start()
    //{
    //    LsystemScript lScript = new LsystemScript();

    //}

    public void ChangeSoil()
    {
        //generatedTreeExists = lScript.statusTreeGeneration();

        Vector3 unscaledSoil = new Vector3(379.7141f, 2.188555f, 390.2904f);

        //Change state of soil only when a plant has yet to be generated
        //if (!generatedTreeExists)
        //{
            if (!originalSoilState)
            {
                transform.localScale = scaledSoil;
                originalSoilState = true;

            }
            else if (originalSoilState)
            {
                transform.localScale = unscaledSoil;
                originalSoilState = false;
            }

        //}
        //else
        //{
        //    print("Can't change state of soil after plant has been generated!");
        //}

    }

}
