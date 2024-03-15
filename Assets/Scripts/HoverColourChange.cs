using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverColourChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Renderer materialRenderer;
    private Color newMaterialColour = Color.yellow;
    private Color originalMaterialColour;

    private void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        originalMaterialColour = materialRenderer.material.color;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        materialRenderer.material.color = newMaterialColour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        materialRenderer.material.color = originalMaterialColour;
    }

}
