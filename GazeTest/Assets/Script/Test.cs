using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TobiiXR.FocusedObjects.Count > 0)
        {
            // The object being focused by the user, determined by G2OM.
            Debug.Log("findit");
            var focusedObject = TobiiXR.FocusedObjects[0];
            Debug.Log(focusedObject);
        }

    }
}
