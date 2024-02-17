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
  
    public void ChangeSoil()
    {
        Vector3 unscaledSoil = new Vector3(379.7141f, 2.188555f, 390.2904f);

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

    }

}
