using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TennisBall tennisBall;
    public Rigidbody ballRigidbody;
    private int mypoints = 0;
    private int otherpoints = 0;
    public Text mypointsText;
    public Text otherpointsText;

    private int lastlose = 0;
    public bool isBallPaused = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isBallPaused)
            { shootagain(); }


        Vector3 Ballposition = tennisBall.transform.position;
        if (Ballposition.x > 19)
        {
            mypoints += 1;
            lastlose = 2;
            mypointsText.text = "" + mypoints;
            RestartGame();
        }
        if (Ballposition.x < -19)
        {
            otherpoints += 1;
            lastlose = 1;
            otherpointsText.text = "" + otherpoints;
            RestartGame();
        }

        if(mypoints > 9 || otherpoints > 9){
            mypoints = 0;
            otherpoints = 0;
        }
    }
    public void RestartGame()
    {
        isBallPaused = true;
        ballRigidbody.Sleep();
        if (lastlose == 1)
        {
            tennisBall.transform.position = new Vector3(-17f, 2f, 0f);
        }
        else if (lastlose == 2)
        {
            tennisBall.transform.position = new Vector3(17f, 5f, 0f);
            StartCoroutine(player2shootback());
        }
        ballRigidbody.WakeUp();
    }
    void shootagain()
    {
        isBallPaused = false;
        if (lastlose == 1)
        {
            Debug.Log("Space key pressed!");
            float randomValue = Random.Range(-10f, 10f);
            tennisBall.ShootBall(new Vector3(-17.22f, 5f, 0f), new Vector3(17.22f, 8f, randomValue));
        }
        else if (lastlose == 2)
        {
            Debug.Log("Space key pressed!");
            float randomValue = Random.Range(-10f, 10f);
            tennisBall.ShootBall(new Vector3(17.22f, 8f, transform.position.z), new Vector3(-17.22f, 8f, randomValue));
        }
    }
    IEnumerator player2shootback(){
        yield return new WaitForSeconds(3.0f);  // Adjust the delay as needed
        float randomValue = Random.Range(-10f, 10f);
        tennisBall.ShootBall(new Vector3(17.22f, 8f, transform.position.z), new Vector3(-17.22f, 8f, randomValue));
    }
}