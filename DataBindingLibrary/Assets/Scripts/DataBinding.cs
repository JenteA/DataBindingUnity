using System.Collections.Generic;
using UnityEngine;


public class DataBinding : MonoBehaviour
{
    public List<GameObject> AllCanvasElements = new List<GameObject>();
    // Use this for initialization
    void Update ()
	{
        AllCanvasElements.Clear();
        int i = 0;
        foreach (var Element in GameObject.FindGameObjectsWithTag("UI"))
        {
            AllCanvasElements.Add(Element);
            print(Element.name);
	        i++;
	    }
	}
}
