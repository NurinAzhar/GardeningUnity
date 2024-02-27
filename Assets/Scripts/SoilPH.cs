using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoilPH : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler /*IEndDragHandler*/
{

    public TMP_Text text;
    //GameObject currentDropped = null;

    public enum SoilPh
    {
        Acidic,
        Alkaline
    }

    public float phRange;

    //initialising ph value of soil
    public void SetRandom()
    {
        phRange= UnityEngine.Random.Range(0f, 14f);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = "Soil pH: " + phRange.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.text = "";
    }

    public void OnDrop(PointerEventData eventData)
    {

        //GameObject currentDropped = GetComponent<CopyAndDrag>().itemDragged;

        GameObject currentDropped = eventData.pointerDrag;

        GameObject sodiumNitrate = GameObject.Find("SodiumNitrate");

        if (currentDropped != null)
        {
            if (currentDropped == GameObject.Find("AmmoniumSulfate"))
            {
                print("Ammonium Sulfate detected");
            }
            else if (currentDropped == GameObject.Find("SodiumNitrate"))
            {
                print("Sodium Nitrate detected");
            }
        } 

    }

    //called only once to set initial ph value of soil
    public void Start()
    {
        SetRandom();
    }

    public void Update()
    {
        
    }

}
