using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverColourChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Renderer materialRenderer;
    private Color newMaterialColour = Color.yellow;
    private Color newMaterialColourLow = Color.blue;
    private Color originalMaterialColour;

    private void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        originalMaterialColour = materialRenderer.material.color;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        int lightIntensity = gameObject.GetComponentInChildren<LsystemScript>().lightIntensity;

        if (lightIntensity <= 1) // Highlight blue for low light shaded ground
        {
            materialRenderer.material.color = newMaterialColourLow;
        }
        else if (lightIntensity > 1) // Highlight yellow for high light shaded ground
        {
            materialRenderer.material.color = newMaterialColour;
            
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        materialRenderer.material.color = originalMaterialColour;
    }

}
