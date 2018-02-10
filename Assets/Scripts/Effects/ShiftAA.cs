using UnityEngine;
using System.Collections;

//Note: requires 60+ FPS for the stable work. Any drop will cause vision artifacts.
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ShiftAA : MonoBehaviour
{
    public	float 		shiftAmount 			= 0.012f;

    private	Camera 		cam 					= null;
	private	bool 		currentlyShifted		= false;

	private	Vector3 	shiftOffsetVector 		= Vector3.zero; 
	private	Vector3		TRSVector				= new Vector3(1.0f, 1.0f, -1.0f);

    private void Start()
	{
        cam = GetComponent<Camera>();
    }

    private void LateUpdate ()
	{
		if(shiftOffsetVector.y != shiftAmount)
			shiftOffsetVector = new Vector3(0.0f, shiftAmount, shiftAmount);

		if (currentlyShifted)
			cam.ResetWorldToCameraMatrix();
        else
		{
			Matrix4x4 m = Matrix4x4.TRS(shiftOffsetVector, Quaternion.identity, TRSVector);
			cam.worldToCameraMatrix = m * transform.worldToLocalMatrix;
        }

		currentlyShifted = !currentlyShifted;
    }
}