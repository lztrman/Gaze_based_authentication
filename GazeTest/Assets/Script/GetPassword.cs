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


    void Start()
    {
        _passwordLength = _password.Length;
        line = new GameObject();
        line.transform.position = new Vector3(0,0,0);
        line.AddComponent<LineRenderer>();
        _lr = line.GetComponent<LineRenderer>();
        _lr.startWidth = 0.1f;
        _lr.endWidth = 0.1f;
        //_lr.material = new Material(Shader.Find("ParticleSystem"));
        _lr.startColor = Color.white;
        _lr.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (_getInput)
        {
            if (TobiiXR.FocusedObjects.Count > 0)
            {
                var focusedObject = TobiiXR.FocusedObjects[0].GameObject;
                passwordInput.Add(focusedObject);
                _getInput = false;
                InvokeRepeating("startinput",2,5);
            }
        }
        //if (TobiiXR.FocusedObjects.Count > 0)
        //{
        // The object being focused by the user, determined by G2OM.
        //var focusedObject = TobiiXR.FocusedObjects[0];
        //GameObject lookingTo = focusedObject.GameObject;

        //}
        //for(int i = 0; i < passwordInput.Count - 1; i++)
        //{
        //DrawLine(passwordInput[i].transform.position, passwordInput[i + 1].transform.position, Color.black, 10);
        //}
        Debug.Log(_lr.positionCount);
        //if (_lr.positionCount != passwordInput.Count)
        //{
            //_lr.positionCount = passwordInput.Count;
           // for (int i = 0; i < passwordInput.Count; i++)
           // {
              //  _lr.SetPosition(i, passwordInput[i].transform.position);
           // }
        //}

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