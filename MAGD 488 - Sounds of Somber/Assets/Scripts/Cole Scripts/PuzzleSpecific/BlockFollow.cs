using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFollow : MonoBehaviour
{
    public float maxDistance;
    public float snapForce;
    public float additionalJumpSpeed, additionalMoveSpeed;

    public Transform playerTransform;
    public Rigidbody2D playerRigidBody;
    private Rigidbody2D myRigidBody;
    private PlayerControl myPlayerControl; 

    public Color c1;
    public Color c2;
    public int lengthOfLineRenderer = 2;

    public bool snapPlayer;

    // Start is called before the first frame update

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        GameObject userPlayer = GameObject.FindGameObjectWithTag("Player"); 

        if (userPlayer != null)
        {
            playerTransform = userPlayer.transform;  
            playerRigidBody = userPlayer.GetComponent<Rigidbody2D>();
            myPlayerControl = userPlayer.GetComponent<PlayerControl>(); 
        }

        LineSettings(); 
    }

    // Update is called once per frame
    void Update()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, playerTransform.position);

        float distY = Mathf.Abs(playerTransform.position.y - gameObject.transform.position.y);
        float distX = Mathf.Abs(playerTransform.position.x - gameObject.transform.position.x); 

        if (CheckPlayerOverDistance())
        {
            myPlayerControl.needKinematicOff = true; 
            BlockMoveReverse(); 
            snapPlayer = true; 
            SnapBack(distX, distY); 
        }
        else if (!CheckPlayerOverDistance())
        {
            myPlayerControl.needKinematicOff = false; 
            snapPlayer = false;
            BlockMove();
        }
    }

    void LineSettings()
    {
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

    bool CheckPlayerOverDistance()
    {
        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) >= maxDistance)
        {
            return true;
        }
        else
        {
            return false; 
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
                //Debug.Log("Add force left");
                playerRigidBody.AddForce(transform.right * -1 * snapForce);
            }
            //box is to the right
            else
            {
                //Debug.Log("Add force right");
                playerRigidBody.AddForce(transform.right * snapForce);
            }

        }
        //more to the left than to the right
        else if (distY > distX)
        {
            //box is below
            if (gameObject.transform.position.y < playerTransform.position.y)
            {
                //Debug.Log("Add force down");
                playerRigidBody.AddForce(transform.up * -1 * snapForce);
            }
            //box is above
            else
            {
                //Debug.Log("Add force up");
                playerRigidBody.AddForce(transform.up * snapForce);
            }
        }
    }

    void BlockMove()
    {
        if (!snapPlayer)
        {
            if (playerRigidBody.velocity.x > 1)
            {
                myRigidBody.velocity = new Vector2(playerRigidBody.velocity.x + additionalMoveSpeed, playerRigidBody.velocity.y);
            }
            else if (playerRigidBody.velocity.x < -1)
            {
                myRigidBody.velocity = new Vector2(playerRigidBody.velocity.x - additionalMoveSpeed, playerRigidBody.velocity.y);
            }
            else
            {
                myRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y);
            }

            if (myPlayerControl.hasJumped)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, playerRigidBody.velocity.y + additionalJumpSpeed);

            }
        }
        else
        {
            ZeroVelocity();
        }
    }

    void BlockMoveReverse()
    {
        float directionSpeed = 5f;
        float moveYSpeed, moveXSpeed; 
        
        
        if (playerTransform.position.x < gameObject.transform.position.x)
        {
            moveXSpeed = directionSpeed * -1; 
        }
        else if (playerTransform.position.x > gameObject.transform.position.x)
        {
            moveXSpeed = directionSpeed;
        }
        else
        {
            moveXSpeed = 0; 
        }

        if (playerTransform.position.y < gameObject.transform.position.y)
        {
            moveYSpeed = directionSpeed * -1;
        }
        else if (playerTransform.position.y > gameObject.transform.position.y)
        {
            moveYSpeed = directionSpeed;
        }
        else
        {
            moveYSpeed = 0; 
        }

        myRigidBody.velocity = new Vector2(moveXSpeed, moveYSpeed); 

    }

    void ZeroVelocity()
    {
        myRigidBody.velocity = new Vector2(0, 0);
    }
}
