using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(DistanceJoint2D))]
public class BatScript : MonoBehaviour {

	//Batgrapin
	LineRenderer lineRend;
	DistanceJoint2D joint;

	//avoid colliding with blinder
	public LayerMask WhatToHit;

	void Start () 
	{
		lineRend = GetComponent<LineRenderer>();
		joint = GetComponent<DistanceJoint2D>();
		joint.enabled = false;
	}
	
	void Update () 
	{
		RaycastHit2D ray;
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		ray = Physics2D.Raycast(transform.position, new Vector2(0, 1), 10f, WhatToHit);
		if (ray.collider != null && Input.GetKey(KeyCode.UpArrow))
		{
			joint.enabled = true;
			lineRend.enabled = true;
			joint.connectedAnchor =(Vector2) ray.collider.gameObject.transform.position;
			joint.anchor = new Vector2(0, 0);
			lineRend.SetPosition(0, transform.position);
			lineRend.SetPosition(1, ray.collider.gameObject.transform.position);
		}
		else
		{
			lineRend.enabled = false;
			joint.enabled = false;
		}
	}
}
