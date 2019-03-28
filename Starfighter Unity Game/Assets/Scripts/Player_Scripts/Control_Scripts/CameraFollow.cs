using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform gamePlayer;

    public float moveSpeed;

    public Vector3 offset;

    public float rotOffset;

	private void Start ()
	{
		
	}

	private void Update()
	{
		
	}

	private void LateUpdate ()
	{
        //Vector3 desiredPosition = gamePlayer.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;
        //Quaternion newRotation = Quaternion.AngleAxis(rotOffset, Vector3.forward) * Quaternion.LookRotation(gamePlayer);
        //Quaternion desiredRotation = gamePlayer.rotation + rotOffset;
        //Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, newRotation, moveSpeed * Time.deltaTime);
        //transform.rotation = smoothedRotation;
    }
}
