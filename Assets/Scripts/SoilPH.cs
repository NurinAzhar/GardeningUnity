using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoilPH : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text text;

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

    //called only once to set initial ph value of soil
    public void Start()
    {
        SetRandom();
    }

    public void Update()
    {
        
    }
}
