using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldAccelerator : MonoBehaviour
{
	static float[] factors = {0f, .25f, .5f, .75f, 1f, 1.25f, 1.5f, 1.75f, 2f, 4f, 8f};

	public Text valueText;
	public Text axesText;

	int factorIndex;
	float factor;
	bool xz;

	void Start ()
	{
		UpdateFactor ();
	}

	float Normalize (float angle)
	{
		return angle > 180f ? angle - 360f : angle;
	}

	void Update ()
	{
		if (Cardboard.SDK.Triggered) {
			factorIndex = (factorIndex + 1) % factors.Length;
			UpdateFactor ();
			Cardboard.SDK.Recenter ();
		}
		if (Cardboard.SDK.Tilted) {
			xz = ! xz;
			UpdateFactor ();
		}
		Vector3 euler = Cardboard.SDK.HeadPose.Orientation.eulerAngles;
		euler.x = Normalize (euler.x);
		euler.y = Normalize (euler.y);
		euler.z = Normalize (euler.z);

		if (xz) {
			euler.x *= factor;
			euler.z *= factor;
		} else {
			euler.x = transform.rotation.x;
			euler.z = transform.rotation.z;
		}
		euler.y *= factor;
		transform.rotation = Quaternion.Euler (euler);
	}

	void UpdateFactor ()
	{
		factor = factors [factorIndex];
		valueText.text = string.Format ("+{0:0.00}", factor);
		axesText.text = xz ? "x/y/z-axes" : "y-axis";
		axesText.color = xz ? Color.red : Color.white;
	}
}
