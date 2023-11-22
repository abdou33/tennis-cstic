using UnityEngine;

public class TennisBall : MonoBehaviour
{
    public float initialSpeed = 1f;
    public float jumpHeight = 20f; // Adjust this value to control the jump height
    public Vector3 BallPos = new Vector3(0f, 0f, 0f);


    void Start()
    {
        // float randomValue = Random.Range(-10f, 10f);
        // ShootBall(new Vector3(-17f, 5f, 0f), new Vector3(17f, 5f, randomValue));
    }

    void Update()
    {
        BallPos = transform.position;
    }

    public void ShootBall(Vector3 startCharacterPosition, Vector3 targetCharacterPosition)
    {
        Rigidbody ballRb = GetComponent<Rigidbody>();

        // Set the ball's position to the start character's position
        transform.position = startCharacterPosition;
        ballRb.velocity = Vector3.zero;

        // Calculate the direction from the start to the target position
        Vector3 shootDirection = (targetCharacterPosition - startCharacterPosition).normalized;

        // Apply force in the calculated direction with a vertical component for jumping
        ballRb.AddForce(shootDirection * initialSpeed, ForceMode.Impulse);

        // Jumping component
        float timeToReachTarget = Vector3.Distance(startCharacterPosition, targetCharacterPosition) / initialSpeed;
        float verticalVelocity = jumpHeight / timeToReachTarget;
        ballRb.AddForce(Vector3.up * verticalVelocity, ForceMode.Impulse);
    }
}
