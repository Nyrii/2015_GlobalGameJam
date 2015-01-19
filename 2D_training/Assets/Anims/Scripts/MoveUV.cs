using UnityEngine;
using System.Collections;

public class MoveUV : MonoBehaviour {
	MeshRenderer render;
	public float parralax = 10f;

	void Start () 
	{
		render = GetComponent<MeshRenderer> ();
	}
	
	void Update () 
	{
		render.material.mainTextureOffset = (Vector2) transform.position / parralax;
	}
}

