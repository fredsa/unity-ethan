using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FpsCounter : MonoBehaviour
{
	private Text text;
	private float fps = 60;

	void Awake ()
	{
		text = GetComponent<Text> ();
	}

	void Update ()
	{
		float interp = Time.deltaTime / (0.5f + Time.deltaTime);
		float currentFPS = 1.0f / Time.deltaTime;
		fps = Mathf.Lerp (fps, currentFPS, interp);
		text.text = string.Format ("{0:0} fps", fps);
	}
}
