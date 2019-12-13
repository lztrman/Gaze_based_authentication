using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class GetPassword : MonoBehaviour
{
    string _password = "123654789";
    List<GameObject> passwordInput = new List<GameObject>();
    int _passwordLength;
    bool _getInput = true;
    // Start is called before the first frame update
    private GameObject line;
    private LineRenderer _lr;
    private int matchCount = 0;
    private string testPassword = "";
    public GameObject textbox;

    void Start()
    {
        _passwordLength = _password.Length;
        line = new GameObject();
        line.transform.position = new Vector3(0,0,0);
        line.AddComponent<LineRenderer>();
        _lr = line.GetComponent<LineRenderer>();
        _lr.startWidth = 0.05f;
        _lr.endWidth = 0.05f;
        //_lr.material = new Material(Shader.Find("Default-Diffuse"));
        _lr.startColor = Color.white;
        _lr.endColor = Color.white;
        //Debug.Log("1".Equals(_password.Substring(0, 1)));
    }

    // Update is called once per frame
    void Update()
    {
        
        textbox.GetComponent<UnityEngine.UI.Text>().text = testPassword;
        if (_getInput)
        {
            if (TobiiXR.FocusedObjects.Count > 0)
            {
                var focusedObject = TobiiXR.FocusedObjects[0].GameObject;
                testPassword = "";
                if(passwordInput.Contains(focusedObject) == false) { passwordInput.Add(focusedObject); }
                
                foreach(GameObject i in passwordInput)
                {
                    testPassword += i.name;
                    //i.GetComponent<BoxCollider>().enabled = false;
                }
                Debug.Log(testPassword+ " " + _password.Substring(0, testPassword.Length));
                if (testPassword.Equals(_password.Substring(0, testPassword.Length)))
                {
                    matchCount++;
                    Debug.Log(matchCount);
                }
                else
                {
                    matchCount = 0;
                    foreach(GameObject i in passwordInput)
                    {
                        //i.GetComponent<BoxCollider>().enabled = true;
                    }
                    passwordInput = new List<GameObject>();
                }
                _getInput = false;
                if(testPassword.Length == _passwordLength)
                {
                    testPassword = "Sucessfully unlock";
                }
                else
                {
                    InvokeRepeating("startinput", 1, 5);
                }
            }

        }

        //Draw the line that consists of the objects stored in the list
        if (_lr.positionCount != passwordInput.Count)
        {
            _lr.positionCount = passwordInput.Count;
           for (int i = 0; i < passwordInput.Count; i++)
           {
              _lr.SetPosition(i, passwordInput[i].transform.position);
           }
        }
        
    }

    void startinput()
    {
        _getInput = true;
        CancelInvoke();
    }

    // Copy from https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //_lr.material = new Material(Shader.Find("ParticleSystem"));
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}