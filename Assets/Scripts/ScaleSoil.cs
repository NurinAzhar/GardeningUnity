using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleSoil : MonoBehaviour
{
    public Vector3 scaledSoil = new Vector3 (379.7141f, 500f, 390.2904f);
    public Vector3 unscaledSoil;
    public Vector3 currentSoil;
    public Boolean originalSoilState = false;
    public Boolean hasChanged = false;
    public Vector3 soilScale;
    public int timeDelay = 1;


    public void ChangeSoil()
    {

        Vector3 unscaledSoil = new Vector3(379.7141f, 2.188555f, 390.2904f);
        hasChanged = true;

        if (!originalSoilState)
       {
            transform.localScale = scaledSoil;
            originalSoilState = true;
                
            currentSoil = scaledSoil;

       }
       else if (originalSoilState)
       {
            transform.localScale = unscaledSoil;
            originalSoilState = false;

            currentSoil = unscaledSoil;

       }

    }

    public void checkChange()
    {

        hasChanged = false;

    }

    public void Update()
    {
        // 1 second delay in changing boolean hasChanged back to false
        Invoke("checkChange", 1);
    }

}
