using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasOpener : MonoBehaviour , IPointerClickHandler
{
    public static GameObject Canvas11, Canvas12, Canvas13, Canvas14, Canvas21, Canvas22, Canvas23, Canvas24,
                      Canvas31, Canvas32, Canvas33, Canvas34, Canvas41, Canvas42, Canvas43, Canvas44;

    public List<GameObject> canvases = new List<GameObject>{ Canvas11, Canvas12, Canvas13, Canvas14, Canvas21, Canvas22, Canvas23, Canvas24,
                      Canvas31, Canvas32, Canvas33, Canvas34, Canvas41, Canvas42, Canvas43, Canvas44 };


    public GameObject Canvas;
  
    public void OpenCanvas() 
    {
        if (Canvas != null) 
        {
            Canvas.SetActive(true);
        }
        
    }

    public void ClearCanvas()
    {
        for (int index = 0; index < canvases.Count; index++)
        {
            canvases[index].SetActive(false);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!Canvas.activeInHierarchy)
        {
            ClearCanvas();
            OpenCanvas();
        }
        else
        {
            Canvas.SetActive(false);
        }

    }
}
