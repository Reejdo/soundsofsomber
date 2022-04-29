using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public Transform target, floorTarget;
	public Vector3 offset;
	Vector3 targetPos;
	public float interpTime;
	public string followTag;

	[SerializeField] private float heightFloor;
	private PlayerControl myPlayerControl;
	private bool followPlayer, followOther;
	public bool needHeightFloor = false; 


	void Start()
	{

		myPlayerControl = target.gameObject.GetComponent<PlayerControl>(); 


		targetPos = transform.position;

		if (target == null)
        {
			target = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Transform>();
		}

		if (floorTarget == null)
        {
			floorTarget = GameObject.FindGameObjectWithTag(followTag).GetComponent<Transform>();
		}
	}

    private void Update()
    {
		if (needHeightFloor)
        {
			CheckFollowTarget();
		}

    }


	// Update is called once per frame
	void FixedUpdate()
	{
		if (needHeightFloor)
        {
			if (followOther)
			{
				LerpToTarget(floorTarget);
			}

			else if (followPlayer)
			{
				LerpToTarget(target);
			}
		}
        else
        {
			LerpToTarget(target);
		}
	}

	void CheckFollowTarget()
    {

		if (target.transform.position.y < heightFloor)
        {
			followOther = true;
			followPlayer = false; 
		}

		if ((target.transform.position.y >= heightFloor) && myPlayerControl.IsGrounded())
        {
			followOther = false;
			followPlayer = true; 
        }
    }


	void LerpToTarget(Transform thisTarget)
    {
		Vector3 posNoZ = transform.position;
		posNoZ.z = target.transform.position.z;

		Vector3 targetDirection = (thisTarget.transform.position - posNoZ);

		interpVelocity = targetDirection.magnitude * 5f;

		targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

		transform.position = Vector3.Lerp(transform.position, targetPos + offset, interpTime);

	}


}
