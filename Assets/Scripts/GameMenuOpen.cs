using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuOpen : MonoBehaviour
{
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
            } 
            else
            {
                menu.SetActive(true);
            }
        }
    }
}
