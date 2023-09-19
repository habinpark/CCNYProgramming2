using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyType;
    public GameObject myType;
    public float speed = 0.05f;
    public string hunterType;
    GameObject closestEnemy;
    GameObject closestHunter;
    GameObject lastCollided;
    public float forceAmount = 1f;
    float distToClosestEnemy;
    float distToClosestHunter;

    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = FindClosestEnemy();
        //enable the 2d collider component
        GetComponent<Collider2D>().enabled = true;
        //enable the script component
        GetComponent<EnemyController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //slowly increase speed over time using deltatime
        //speed += Time.deltaTime / 1000;
        closestEnemy = FindClosestEnemy();
        closestHunter = FindClosestHunter();
        
        if (closestEnemy != null && closestHunter != null)
        {
            //find the closest enemy and set distToClosestEnemy to the distance to that enemy
            distToClosestEnemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
            //find the closest hunter and set distToClosestHunter to the distance to that hunter
            distToClosestHunter = Vector3.Distance(transform.position, closestHunter.transform.position);

            //if the distance to the closest enemy is less than the distance to the closest hunter then move towards the closest enemy
            if (distToClosestEnemy < distToClosestHunter)
            {
                transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);
            }
            else
            {
                //move away from the closest hunter
                transform.position = Vector3.MoveTowards(transform.position, closestHunter.transform.position, -speed);
            }
        }
        else if(closestHunter != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestHunter.transform.position, -speed);
        }
        else if(closestEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);
        }
        else
        {

        }


        //find the closest enemy and set distToClosestEnemy to the distance to that enemy
        //distToClosestEnemy = Vector3.Distance(transform.position, closestEnemy.transform.position);
        //find the closest hunter and set distToClosestHunter to the distance to that hunter
        //distToClosestHunter = Vector3.Distance(transform.position, closestHunter.transform.position);

        //if the distance to the closest enemy is less than the distance to the closest hunter then move towards the closest enemy
        //if (distToClosestEnemy < distToClosestHunter)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);
        //}
        //else
        //{
            //move away from the closest hunter
       //     transform.position = Vector3.MoveTowards(transform.position, closestHunter.transform.position, -speed);
        //}

        //transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);

    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(enemyType);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public GameObject FindClosestHunter()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(hunterType);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    //on collision with object tagged enemyType destroy object and spawn myType object with a random force amount
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (lastCollided != collision.gameObject)
        {
            lastCollided = collision.gameObject;

            if (collision.gameObject.tag == enemyType)
            {
                Destroy(collision.gameObject);
                GameObject myTypeClone = Instantiate(myType, transform.position, Quaternion.identity);
                //enable the clone 2d collider component
                myTypeClone.GetComponent<Collider2D>().enabled = true;
                //enable the clone script component
                myTypeClone.GetComponent<EnemyController>().enabled = true;
                //set collided object to lastCollided
                myTypeClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * forceAmount);


            }
        }
        else
        {
            //do nothing
        }
        lastCollided = collision.gameObject;

    }
}
