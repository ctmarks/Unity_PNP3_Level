using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	[SerializeField]
	private Health CurHealth;

	[SerializeField]
	private Text myGuiText;

	void Start ()
	{
		if(myGuiText == null)
		{
			Debug.LogWarning("No \"text\" component assigned to " + name);
		}
	}

	void Update() {
		if(myGuiText!=null)
		{
			myGuiText.text = "" + CurHealth.currentHealth + "/" +CurHealth.maxHealth;
		}
	}
}

