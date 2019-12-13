using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Tobii.G2OM;



public class ChangeAtGaze : MonoBehaviour, IGazeFocusable
{
    private string txt;
    public GameObject database;
    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus)
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.ToUpper();
            Debug.Log(database.GetComponent<Data>().locked & database.GetComponent<Data>().getInput);
            if (database.GetComponent<Data>().locked & database.GetComponent<Data>().getInput)
            {
                if (database.GetComponent<Data>().passwordtest.Contains(gameObject) == false)
                {
                    database.GetComponent<Data>().passwordtest.Add(gameObject);
                    database.GetComponent<Data>().setInput();  
                }
                database.GetComponent<Data>().matchCount = match();
            }
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.ToLower();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.Find("Database");
    }

    
    // Update is called once per frame
    void Update()
    {

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