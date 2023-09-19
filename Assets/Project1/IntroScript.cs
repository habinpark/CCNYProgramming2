using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    //make public variable for scene
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if press space open samplescene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //load scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
