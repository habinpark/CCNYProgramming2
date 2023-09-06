using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject bottomLeft;
    public GameObject bottomRight;

    public GameObject enemy;

    float timer = 0.0f;
    //make variable for tmpro text
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set timerText to "Timer: " + timer rounded to the nearest 2 decimal places
        timerText.text = "Timer: " + timer.ToString("F2");


        
        timer += Time.deltaTime;
        Debug.Log(Time.deltaTime);
        //spawn enemy in random location between the 4 corners
        if (timer >= 5f)
        {
            float x = Random.Range(topLeft.transform.position.x, topRight.transform.position.x);
            float y = Random.Range(bottomLeft.transform.position.y, topLeft.transform.position.y);
            Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
            //print out timer to console
            Debug.Log(Time.deltaTime);
            timer = 0.0f;
        }
        //create a timer for 5 seconds
       


    }
}
