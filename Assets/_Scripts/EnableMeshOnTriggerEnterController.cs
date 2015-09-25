using UnityEngine;
using System.Collections;

public class EnableMeshOnTriggerEnterController : MonoBehaviour
{

	MeshRenderer mr;

	void Start ()
	{
		mr = GetComponent<MeshRenderer> ();
		mr.enabled = false;
	}

	void OnTriggerEnter (Collider other)
	{
		mr.enabled = true;
	}
	
	void OnTriggerExit (Collider other)
	{
		mr.enabled = false;
	}

}
