using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dial : MonoBehaviour
{
    public GameObject textbox;
    private int radius = 200;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject a = Instantiate(textbox, gameObject.transform, false);
            a.transform.localPosition = new Vector3(Mathf.Sin((i / 10f) * (2 * Mathf.PI)) * radius, Mathf.Cos((float)(i / 10f) * (2 * Mathf.PI)) * radius, 0f);
            a.GetComponent<BoxCollider>().enabled = true;
            a.GetComponent<UnityEngine.UI.Text>().text = i.ToString();
            a.name = i.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
