using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Create an empty game object contain this script and make it become a public database.
public class NewDATA : MonoBehaviour
{
    public List<GameObject> passwordtest = new List<GameObject>(); // One textbox stands for one digit, store the textboxes in this list to represent the password the users input.
    public string password = "123654";
    private string testpassword = "";
    public int matchCount = 0;  // Count the number of digits that has fit with the password so far
    public GameObject textbox;
    public GameObject lastGaze;
    public bool locked = true;  //if the password users input match with that stored in the server, it would change to false and system stop the aithentication system
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (matchCount == password.Length)   //If the password users input is identical with the that is stored in, give a feedback and terminate the system.
        {
            locked = false;                                                              
            textbox.GetComponent<UnityEngine.UI.Text>().text = "Sucessfully unlock";
        }
    }


    // If the password is not match, give a response information to users.
    public void wrongPass()
    {
        
        textbox.GetComponent<UnityEngine.UI.Text>().text = "wrong";
    }

    //Show the password users input so far on a textbox
    public void display(string input)   
    {
        textbox.GetComponent<UnityEngine.UI.Text>().text = input;
    }
}
