using UnityEngine;
using System.Collections;

public class PlaneBehaviour : MonoBehaviour {
	public float Velocity = 5f;
	public float Velocity_rot = 180f;
	public int life = 100;
	public GameObject GameOver;
	public HealthBar hbar;

	Animator anim;
	int animHash = Animator.StringToHash("StartAnim");
	int anim2Hash = Animator.StringToHash("StartAnim2");

	void Start()
	{
		hbar = GameObject.Find("Image").GetComponent<HealthBar>();
		anim = GetComponent<Animator>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			anim.SetTrigger(animHash);
			//anim.SetBool("StartAnim", true); //equivalent
		}
		else
		{
			anim.ResetTrigger(animHash);
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			anim.SetTrigger(anim2Hash);
		}
		else
		{
			anim.ResetTrigger(anim2Hash);
		}

		Quaternion rot = transform.rotation;
		float z_rot = rot.eulerAngles.z;
		//z_rot -= Input.GetAxis ("Horizontal") * Time.deltaTime * Velocity_rot;
		//rot = Quaternion.Euler (0, 0, z_rot);
		//transform.rotation = rot;

		transform.position += rot * new Vector3 (Input.GetAxis("Fire1") * Velocity * Time.deltaTime, 0, 0);

		var objectPos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - objectPos; 
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		hbar.loosingLife (5);
		life -= 5;
		Destroy (col.gameObject);
		if (life < 0)
		{
			GameManager.GM.resetLevel();
			Destroy(gameObject);
		}
	}
}
