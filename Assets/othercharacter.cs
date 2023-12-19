using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othercharacter : MonoBehaviour
{
    public TennisBall tennisBall;

    // Update is called once per frame
    void Update()
    {
        // follow the ball on z Axis
        transform.position = new Vector3(transform.position.x, transform.position.y, tennisBall.transform.position.z);
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball, if so shoot the ball (95%)
        if (collision.gameObject.CompareTag("TennisBall"))
        {
            bool catchit = Random.Range(0f, 1f) > 0.05f;
            if (catchit)
            {
                float randomValue = Random.Range(-10f, 10f);
                tennisBall.ShootBall(new Vector3(17.22f, 8f, transform.position.z), new Vector3(-17.22f, 8f, randomValue));
            }
            else
            {
                tennisBall.transform.position = new Vector3(19.1f, 5f, 0f);
            }
        }
    }
}
