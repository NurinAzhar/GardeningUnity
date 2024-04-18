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
    public SoilPh phLevel;
    public GameObject pest;

    public GameObject rowCover;
    public GameObject FRCButton;
    public int count;

    public enum SoilPh
    {
        Neutral,
        Acidic,
        Alkaline
    }
    
    // pH value of soil
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

        FRCButton = GameObject.Find("FRC Button");
        count = FRCButton.GetComponent<CopyDragDestroyScript>().count;

        if (currentDropped != null)
        {

            if (currentDropped == GameObject.Find("AmmoniumSulfate")) //decrease pH soil
            {
                print("Ammonium Sulfate detected");

                phRange = phRange - UnityEngine.Random.Range(3f, 5f);
            }
            else if (currentDropped == GameObject.Find("SodiumNitrate")) //increase pH soil
            {
                print("Sodium Nitrate detected");

                phRange = phRange + UnityEngine.Random.Range(3f, 5f);
            }
            else if (currentDropped == GameObject.Find("Pesticide")) //Handles Pesticide detection
            {
                GetComponent<PestGenerator>().StopAllCoroutines();

                if (pest.activeInHierarchy)
                {
                    GetComponentInChildren<PestBehaviour>().StopAllCoroutines();
                    pest.SetActive(false);
                }
            }
            else if (currentDropped == GameObject.Find("FRC Button"))
            {
                if (!rowCover.activeInHierarchy && count < 3)
                {
                    rowCover.SetActive(true);
                    FRCButton.GetComponent<CopyDragDestroyScript>().count += 1;
                }
                else
                {
                    if (rowCover.activeInHierarchy) 
                    { 
                        rowCover.SetActive(false);
                        FRCButton.GetComponent<CopyDragDestroyScript>().count -= 1;
                    }
                }
            }
        } 

    }

    //called only once to set initial random ph value of soil
    public void Start()
    {
        SetRandom();
    }

    public void Update()
    {
        // Keep phRange out of the negatives and out of the range of 0 - 14
        if (phRange < 0f)
        {
            phRange = 0.1f;
        } 
        else if  (phRange > 14f)
        {
            phRange = 14f;
        } 
        else if (phRange >= 0 && phRange <= 6.9)
        {
            phLevel = SoilPh.Acidic;

        }
        else if (phRange == 7)
        {
            phLevel = SoilPh.Neutral;

        }
        else if (phRange >= 7.1 &&  phRange <= 14)
        {
            phLevel = SoilPh.Alkaline;
        }

    }

    public SoilPh GetPhLevel()
    {
        return this.phLevel;
    }

}
