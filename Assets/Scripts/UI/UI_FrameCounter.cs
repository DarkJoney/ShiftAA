using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_FrameCounter : MonoBehaviour
{
	public Text		fpsCounterText		= null;
	public Color	badFPSColor			= Color.red;
	public Color	goodFpsColor		= Color.green;
	public float	goodFPSThreshold	= 59.0f;

	private void Start()
	{
		Application.targetFrameRate = 60;

		#if UNITY_EDITOR
		if(!fpsCounterText){
			Debug.LogError("UI_FrameCounter Error: FPSCounterText is not set!");
			fpsCounterText = GetComponent<Text>();
		}
		#endif
	}

	private void LateUpdate () 
	{
	
		float currentFPS = Mathf.Floor(1.0f / Time.smoothDeltaTime * 10.0f) / 10.0f;

		if(currentFPS < goodFPSThreshold)
			fpsCounterText.color = badFPSColor;
		else
			fpsCounterText.color = goodFpsColor;

		fpsCounterText.text = currentFPS + " FPS";
	}
}
