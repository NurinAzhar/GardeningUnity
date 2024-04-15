using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PestBehaviour : MonoBehaviour
{
    public GameObject Tree;
    public Boolean generatedTree;
    public float seconds;
    public GameObject pest;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator DeletionDelay(GameObject tree)
   {

        seconds = UnityEngine.Random.Range(5f, 7f); // come back to change timings if neeeded

        yield return new WaitForSeconds((int)seconds);

        Destroy(tree);
        transform.parent.GetComponentInChildren<LsystemScript>().generatedTree = false;
        transform.parent.GetComponentInChildren<LsystemScript>().Reset();

    }

    // Update is called once per frame
   void Update()
   {
        Tree = transform.parent.GetComponentInChildren<LsystemScript>().Tree;

        if (Tree)
        {
            StartCoroutine(DeletionDelay(Tree));
        } 
        
   }
}
