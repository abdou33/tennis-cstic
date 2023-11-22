using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othercharacter : MonoBehaviour
{
    public TennisBall tennisBall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("ball position22: " + tennisBall.BallPos); 
        transform.position = new Vector3(transform.position.x, transform.position.y, tennisBall.BallPos.z);
    }
    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("TennisBall"))
        {
            float randomValue = Random.Range(-10f, 10f);
            tennisBall.ShootBall(new Vector3(17.22f, 8f, transform.position.z), new Vector3(-17.22f, 8f, randomValue));
        }
    }
}
