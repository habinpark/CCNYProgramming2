using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public GameObject player;
    public GameObject scissor;
    public float forceAmount = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //w moves player forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        //s moves player backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        //a moves player left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //d moves player right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
    }
    //on collision with object tagged "paper" destroy object and spawn scissor object
    //and add force in a random direction to the forceAmount to scissor object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print collided
        Debug.Log("Collided");
        if (collision.gameObject.tag == "paper")
        {
            Debug.Log("Collided");

            Destroy(collision.gameObject);
            GameObject scissorClone = Instantiate(scissor, transform.position, Quaternion.identity);

            scissorClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * forceAmount);
            Destroy(collision.gameObject);

        }
    }
}
