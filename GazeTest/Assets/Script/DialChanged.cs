using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class DialChanged : MonoBehaviour, IGazeFocusable
{
    public GameObject Data;
    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.Find("Database");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus)
        {
            if (Data.GetComponent<NewDATA>().locked)
            {
                if (Data.GetComponent<NewDATA>().passwordtest.Contains(gameObject) == false)
                {
                    Data.GetComponent<NewDATA>().lastGaze = gameObject;
                }
            }
        }
    }

}
