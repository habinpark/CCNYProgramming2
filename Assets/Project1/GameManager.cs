using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System.Security.Cryptography.X509Certificates;

public class GameManager : MonoBehaviour
{
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomLeft;
    public GameObject bottomRight;

    public TextMeshProUGUI EndText;
    public TextMeshProUGUI RestartText;
    public TextMeshProUGUI IntroText;

    bool paperExists = true;
    bool scissorExists = true;
    bool rockExists = true;

    public bool introActive = true;
    public bool gameActive = false;
    public bool endActive = false;

    //create a variable for a button
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //create a function that returns an array of all game objects with tag (input)
        GameObject[] paperArray = GameObject.FindGameObjectsWithTag("paper");
        GameObject[] scissorArray = GameObject.FindGameObjectsWithTag("scissor");
        GameObject[] rockArray = GameObject.FindGameObjectsWithTag("rock");

        //check to see if the array is empty
        if (paperArray.Length == 0)
        {
            paperExists = false;
        }
        else if (paperArray.Length > 0)
        {
            paperExists = true;
        }
        if (scissorArray.Length == 0)
        {
            scissorExists = false;
        }
        else if (scissorArray.Length > 0)
        {
            scissorExists = true;
        }
        if (rockArray.Length == 0)
        {
            rockExists = false;
        }
        else if (rockArray.Length > 0)
        {
            rockExists = true;
        }

        //if paper and rock are empty print "scissor wins"
        if (paperExists == false && rockExists == false)
        {
            EndText.text = "Scissor Wins!";
            RestartText.text = "Press R to Restart";
        }
        //else if paper and scissor are empty print "rock wins"
        else if (paperExists == false && scissorExists == false)
        {
            EndText.text = "Rock Wins!";
            RestartText.text = "Press R to Restart";
        }
        //else if rock and scissor are empty print "paper wins"
        else if (rockExists == false && scissorExists == false)
        {
            EndText.text = "Paper Wins!";
            RestartText.text = "Press R to Restart";
        }


        //if r is pressed restart the active scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            //open IntroScene
            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
        }





    }
}
