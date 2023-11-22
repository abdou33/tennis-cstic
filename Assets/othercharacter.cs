using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othercharacter : MonoBehaviour
{
    public TennisBall tennisBall;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, tennisBall.transform.position.z);
        // if (!tennisBall.player2turn)
        // {
        //     Debug.Log("catch it=\t" + tennisBall.catchit);
        //     if (tennisBall.catchit)
        //     {
        //     }
        //     else
        //     {
        //         float lerpSpeed = 0.5f;  // Adjust the speed as needed

        //         tennisBall.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, (tennisBall.landingpointZ + transform.position.z)/2), lerpSpeed);
        //     }
        // }
        // Debug.Log("ball position22: " + tennisBall.BallPos); 
    }
    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("TennisBall"))
        {
            bool catchit = Random.Range(0f, 1f) > 0.2f;
            if(catchit){
                float randomValue = Random.Range(-10f, 10f);
                tennisBall.ShootBall(new Vector3(17.22f, 8f, transform.position.z), new Vector3(-17.22f, 8f, randomValue));
                tennisBall.player2turn = true;
            }
            else{
                tennisBall.transform.position = new Vector3(19.1f, 5f, 0f);
            }
        }
    }
}
