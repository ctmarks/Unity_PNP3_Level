using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Health : MonoBehaviour 
{
	public int maxHealth = 10;
	public int currentHealth;
	public GameObject deathObj = null;
	public AudioClip deathSound = null;
	public Transform respawnMarker = null;
	public bool triggerExplosion = false;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}

	public void ApplyDamage(int amount) 
	{
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
            currentHealth = 0;
            Debug.Log("Death");
			if(deathObj)
			{
				Instantiate(deathObj, transform.position, transform.rotation);
			}

			if(deathSound)
			{
				GetComponent<AudioSource>().clip = deathSound;
				GetComponent<AudioSource>().Play();
			}

			if(triggerExplosion)
			{
				SendMessage("DoDamage", SendMessageOptions.DontRequireReceiver);
			}

			if(respawnMarker)
			{
				transform.position = respawnMarker.position;
				currentHealth = maxHealth;
			}
			else
			{
                gameObject.SetActive(false);
			}
		}
	}
}
