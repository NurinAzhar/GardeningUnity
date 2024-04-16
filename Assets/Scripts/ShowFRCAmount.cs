using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowFRCAmount : MonoBehaviour
{
    public int count;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        count = GameObject.Find("FRC Button").GetComponent<CopyDragDestroyScript>().count;
        text.SetText("Amount Remaining: " + (3-count));
    }
}
