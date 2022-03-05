using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFollow : MonoBehaviour
{
    public float maxDistance;
    public float snapForce;
    public float additionalJumpSpeed; 
    public Transform playerTransform;
    public Rigidbody2D playerRigidBody;
    private Rigidbody2D myRigidBody;
    private TestPlayerControl myPlayerControl; 

    public Color c1;
    public Color c2;
    public int lengthOfLineRenderer = 2;

    // Start is called before the first frame update

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        GameObject userPlayer = GameObject.FindGameObjectWithTag("Player"); 

        if (userPlayer != null)
        {
            playerTransform = userPlayer.transform;  
            playerRigidBody = userPlayer.GetComponent<Rigidbody2D>();
            myPlayerControl = userPlayer.GetComponent<TestPlayerControl>(); 
        }

        //Everything below here is line initiation
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;
        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        BlockMove(); 
        
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, playerTransform.position);

        float distY = Mathf.Abs(playerTransform.position.y - gameObject.transform.position.y);
        float distX = Mathf.Abs(playerTransform.position.x - gameObject.transform.position.x); 

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) > maxDistance)
        {
            SnapBack(distX, distY); 
        }
    }


    void SnapBack(float distX, float distY)
    {
        //more to the right than to the left
        if (distX > distY)
        {
            //box is to the left
            if (gameObject.transform.position.x < playerTransform.position.x)
            {
                Debug.Log("Add force left");
                playerRigidBody.AddForce(transform.right * -1 * snapForce);
            }
            //box is to the right
            else
            {
                Debug.Log("Add force right");
                playerRigidBody.AddForce(transform.right * snapForce);
            }

        }
        //more to the left than to the right
        else if (distY > distX)
        {
            //box is below
            if (gameObject.transform.position.y < playerTransform.position.y)
            {
                Debug.Log("Add force down");
                playerRigidBody.AddForce(transform.up * -1 * snapForce);
            }
            //box is above
            else
            {
                Debug.Log("Add force up");
                playerRigidBody.AddForce(transform.up * snapForce);
            }
        }
    }

    void BlockMove()
    {
        myRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, myRigidBody.velocity.y);

        if (myPlayerControl.hasJumped)
        {
            myRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y + additionalJumpSpeed); 
        }
    }
}
