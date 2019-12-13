using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public List<GameObject> passwordtest = new List<GameObject>();
    public string password = "123654";
    private string testpassword = "";
    public int matchCount = 0;
    public GameObject textbox;
    public bool locked = true;
    private GameObject line;
    private LineRenderer _lr;
    // Start is called before the first frame update
    void Start()
    {
        line = new GameObject();
        line.transform.position = new Vector3(0, 0, 0);
        line.AddComponent<LineRenderer>();
        _lr = line.GetComponent<LineRenderer>();
        _lr.startWidth = 0.05f;
        _lr.endWidth = 0.05f;
        _lr.startColor = Color.white;
        _lr.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lr.positionCount != passwordtest.Count)
        {
            _lr.positionCount = passwordtest.Count;
            for (int i = 0; i < passwordtest.Count; i++)
            {
                _lr.SetPosition(i, passwordtest[i].transform.position);
            }
        }


        if (matchCount == password.Length)
        {
            locked = false;
            textbox.GetComponent<UnityEngine.UI.Text>().text = "Sucessfully unlock";
        }
    }
}
