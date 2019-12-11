using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;


public class ChangeAtGaze: MonoBehaviour, IGazeFocusable
{
    private string txt;
    public void GazeFocusChanged(bool hasFocus)
    {
        
        if (hasFocus)
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.ToUpper();
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.ToLower();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
