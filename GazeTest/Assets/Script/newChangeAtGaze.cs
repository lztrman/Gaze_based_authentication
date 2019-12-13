using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;


public class newChangeAtGaze : MonoBehaviour, IGazeFocusable
{
    public GameObject database;
    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.Find("Database");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus)
        {
            if (database.GetComponent<Data>().locked)
            {
                if (database.GetComponent<Data>().passwordtest.Contains(gameObject) == false)
                {
                    database.GetComponent<Data>().passwordtest.Add(gameObject); 
                }
                database.GetComponent<Data>().matchCount = match();
            }
        }
    }

    int match()
    {
        string testpassword = "";
        foreach (GameObject i in database.GetComponent<Data>().passwordtest)
        {
            testpassword += i.name;
        }

        if (testpassword.Equals(database.GetComponent<Data>().password.Substring(0, testpassword.Length)))
        {
            database.GetComponent<Data>().display(testpassword);
            return testpassword.Length;
        }
        else
        {
            database.GetComponent<Data>().wrongPass();
            database.GetComponent<Data>().passwordtest = new List<GameObject>();
            return 0;
        }
    }
}
