using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public Image healthBar;
	public float playerHealth;
	private float maxHealth = 1;
	public float currentHealth = 1;

	void Start () {
		playerHealth = maxHealth;
		healthBar = GetComponent<Image>();
		healthBar.fillAmount = playerHealth;
	}

	float DecreaseVel = 0f;

	void Update()
	{
		healthBar.fillAmount = Mathf.SmoothDamp (healthBar.fillAmount, currentHealth, ref DecreaseVel, 0.3f);	
	}
	
	public void loosingLife(float amount)
	{
		currentHealth -= amount / 100;
	}
}
