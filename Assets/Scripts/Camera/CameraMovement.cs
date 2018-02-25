using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public	float		distance		= 0.0f;
	public	Transform	anchor			= null;
	public	float		rotationSpeed	= 10.0f;

	private void Start(){

		distance = Vector3.Distance(anchor.position, transform.position);
	}

	private void Update () {
	
		transform.eulerAngles += (Vector3.up * (rotationSpeed * Time.deltaTime));
		transform.position = anchor.position + transform.rotation * (Vector3.back * distance);
	}
}
