using UnityEngine;
using System.Collections;

public class SpawnBlind : MonoBehaviour {
	
	public GameObject blindObj;
	public int startXPos = 0;
	public int startYPos = 0;
	public int endXPos = 0;
	public int endYPos = 0;


	//see invoke
	void Start()
	{
		for(int j = startXPos; j <= endXPos; j++)
		{
			for (int i = startYPos; i <= endYPos; i++)
			{
				GameObject instance = (GameObject) Instantiate(blindObj, new Vector3(i, j, -11), Quaternion.identity);
				//Makes game veeeeery laggy
				//instance.transform.parent = this.gameObject.transform;
			}
		}
	}
}
