using UnityEngine;
using System.Collections;

public class SetupVolume : MonoBehaviour {

	[Header("Setup number")]
	[Range(1, 60)]
	public int setupNum = 1;

	[Header("User story")]
	[TextArea]
	public string msgBody;

	private float msgTime = 7.0f;
	private float volDist = 15.0f;

	[Header("How long does this setup take to complete? (in seconds)")]
	[Range(1, 60)]
	public int timeEstimate = 1;

	[Header("Known issues with setup")]
	[TextArea]
	public string knownIssues;

	private GameObject player;
	private Color32 originalCol;
	private Color32 fadedCol;
	private float startTime;

	private SetupMessageSystem msg;

	private string msgFrom;

	void Start()
	{
		msg = GameObject.FindObjectOfType<SetupMessageSystem>();

		player = GameObject.FindGameObjectWithTag("Player");

		originalCol = GetComponent<Renderer>().material.color;
		fadedCol = originalCol;
		fadedCol.a = 0;

		startTime = Time.time;

		msgFrom = "<b>Setup</b> #" + setupNum + "          <b>Time Estimate:</b> " + timeEstimate + " seconds";
	}

	void Update()
	{
		float distance = Vector3.Distance(transform.position, player.transform.position);

		if (distance <= volDist)
		{
			//am I faded out?
			if (GetComponent<Renderer>().material.color == fadedCol)
			{
				startTime = Time.time;
			}
			else
			{
				//we are close enough, start fading out
				GetComponent<Renderer>().material.color = Color.Lerp(originalCol, fadedCol, Time.time - startTime);
			}
		}
		else if (distance > volDist)
		{
			//am I faded in?
			if (GetComponent<Renderer>().material.color == originalCol)
			{
				startTime = Time.time;
			}
			else
			{
				//we are far away, start fading in
				GetComponent<Renderer>().material.color = Color.Lerp(fadedCol, originalCol, Time.time - startTime);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			msg.NewMessage(msgFrom,msgBody,msgTime);
		}
	}
}
