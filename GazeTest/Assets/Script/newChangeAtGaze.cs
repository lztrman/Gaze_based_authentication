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

    //If this object is focused by users, check if the game object list contain this object. 
    //If not contain this object, add it into the list. it makes the items in the list are unique. 
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

    //Check if the password user input so far is the same with the first substring of password stored in with the same length.
    //If same, return the count of match. If not, return 0.
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
