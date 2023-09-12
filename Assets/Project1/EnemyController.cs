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

    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);
        }
        else if (closestEnemy == null)
        {
            //find the closest hunter and move opposite direction to it
            GameObject closestHunter = FindClosestHunter();
            if (closestHunter != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, closestHunter.transform.position, -speed);
            }
            else
            {
                //nothing to do
            }
        }
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
        if (collision.gameObject.tag == enemyType)
        {
            Destroy(collision.gameObject);
            GameObject myTypeClone = Instantiate(myType, transform.position, Quaternion.identity);
            //myType.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * forceAmount);
        }
    }
}
