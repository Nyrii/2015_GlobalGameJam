using UnityEngine;
using System.Collections;

public class KarmaKeeper : MonoBehaviour {

	[HideInInspector]
	public float karmaSaved = 0.5f;

	void Awake () 
	{
		DontDestroyOnLoad(this.gameObject);
	}
}
