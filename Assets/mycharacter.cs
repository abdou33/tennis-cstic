using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Text;

public class mycharacter : MonoBehaviour
{
    public TennisBall tennisBall;
    public float speed = 25f; // Adjust this value to control the movement speed.
    public float minX = -10f; // Minimum x-position
    public float maxX = 10f;  // Maximum x-position

    // communication
    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    private bool startRecieving = true;
    public float data;

    void Start()
    {
        float randomValue = UnityEngine.Random.Range(-10f, 10f);
        tennisBall.ShootBall(new Vector3(-17.22f, 5f, 0f), new Vector3(17.22f, 8f, randomValue));

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }
    void Update()
    {
        // Get the horizontal input (left/right arrow keys, or A/D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction based on the input
        Vector3 movement = new Vector3(0f, 0f, data * -1);

        // Move the player using the Rigidbody component
        transform.Translate(movement * speed * Time.deltaTime);

        // Clamp the position to stay within the specified range
        float clampz = Mathf.Clamp(transform.position.z, minX, maxX);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampz);

        // Move the player using the Rigidbody component
        transform.Translate(movement * speed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("TennisBall"))
        {
            float randomValue = UnityEngine.Random.Range(-10f, 10f);
            tennisBall.ShootBall(new Vector3(-17.22f, 8f, transform.position.z), new Vector3(17.22f, 8f, randomValue));
        }
    }

    private void ReceiveData()
    {

        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = float.Parse(Encoding.UTF8.GetString(dataByte));
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }
}
