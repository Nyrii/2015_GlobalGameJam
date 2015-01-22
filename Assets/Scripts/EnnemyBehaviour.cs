using UnityEngine;
using System.Collections;

public class EnnemyBehaviour : MonoBehaviour {
	GameObject Target;

	public GameObject bullet;
	public float rot_speed = 100f;
	public float speed = 2f;
	public float fireRate = 1f;
	float fireDelay = 0;
	public float bulletSpeed = 1500f;

	void Update () {
		if (Target == null)
		{
			Target = GameObject.FindGameObjectWithTag("TEST");
		}
		else
		{
			Debug.Log(Target.transform.position);
			fireDelay -= Time.deltaTime;
			Vector3 dif = transform.position - Target.transform.position;
			Quaternion rot = Quaternion.Euler(0, 0, 90 - Mathf.Atan2(dif.x, dif.y) * Mathf.Rad2Deg);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rot_speed * Time.deltaTime);
			transform.position -= rot * new Vector3 (speed * Time.deltaTime, 0, 0);

			RaycastHit2D ray;
			ray = Physics2D.Raycast(transform.position, -transform.right);
			Debug.DrawRay(transform.position, -transform.right);
			if (ray.rigidbody != null && ray.transform.name != null && fireDelay < 0)
			{
				fireDelay = fireRate;
				GameObject bulletInstance = (GameObject) Instantiate(bullet, transform.position, transform.GetChild(0).transform.rotation);
				bulletInstance.rigidbody2D.AddForce(-transform.right * bulletSpeed);
				Destroy(bulletInstance, 5f);
			}
			
		}
	}
}
