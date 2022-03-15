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


	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		myPlayerControl = target.gameObject.GetComponent<PlayerControl>(); 

		floorTarget = GameObject.FindGameObjectWithTag(followTag).GetComponent<Transform>();
		targetPos = transform.position;
	}

    private void Update()
    {
		CheckFollowTarget(); 
    }


	// Update is called once per frame
	void FixedUpdate()
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
