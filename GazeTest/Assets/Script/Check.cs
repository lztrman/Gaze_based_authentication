using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;


// The script for the check button
public class Check : MonoBehaviour , IGazeFocusable
{
    GameObject Data;
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
                if (Data.GetComponent<NewDATA>().lastGaze != null)
                {
                    Data.GetComponent<NewDATA>().passwordtest.Add(Data.GetComponent<NewDATA>().lastGaze);
                    Data.GetComponent<NewDATA>().lastGaze = null;
                }
            }
            Data.GetComponent<NewDATA>().matchCount = match();
        }
    }
    int match()
    {
        string testpassword = "";
        foreach (GameObject i in Data.GetComponent<NewDATA>().passwordtest)
        {
            testpassword += i.name;
        }

        if (testpassword.Equals(Data.GetComponent<NewDATA>().password.Substring(0, testpassword.Length)))
        {
            Data.GetComponent<NewDATA>().display(testpassword);
            return testpassword.Length;
        }
        else
        {
            Debug.Log(testpassword);
            Data.GetComponent<NewDATA>().wrongPass();
            Data.GetComponent<NewDATA>().passwordtest = new List<GameObject>();
            return 0;
        }
    }
}
