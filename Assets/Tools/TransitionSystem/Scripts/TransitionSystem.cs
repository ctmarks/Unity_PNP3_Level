using UnityEngine;

public class TransitionSystem : MonoBehaviour {

    private TransitionPoint[] points;
    public Transform playerPos;

    public MeshRenderer fade;

    private Color opaque;
    private Color transparent;

    public bool fadeOut = false;

    private float lockTimer = 1.0f;
    private float pauseTimer = 1.0f;

    private Vector3 endPos = Vector3.zero;

    void Start()
    {
        //points = GameObject.FindObjectsOfType<TransitionPoint>();

        opaque = Color.black;
        transparent = Color.black;
        transparent.a = 0;

        fade.material.color = transparent;
    }

	void Update()
    {
        points = GameObject.FindObjectsOfType<TransitionPoint>();

        foreach (TransitionPoint tp in points)
        {
            if(tp.isHere == true)
            {
                tp.exitPoint.isExit = true;

                if (fadeOut == true)
                {
                    if(fade.material.color.a >= 0.9f)
                    {
                        fade.material.color = opaque;
                        pauseTimer = 0.0f;
                        tp.TeleportMe();
                        lockTimer = 0.0f;
                        endPos = tp.exitPoint.transform.position;
                        tp.isHere = false;
                        fadeOut = false;
                    }
                    else
                    {
                        playerPos.position = tp.oldPos;
                        fade.material.color = Color.Lerp(fade.material.color, opaque, Time.deltaTime * 5.0f);
                    }
                }
            }
        }

        if(lockTimer < 1.0f)
        {
            lockTimer += Time.deltaTime;
            playerPos.position = endPos;
        }
        else
        {
            lockTimer = 1.0f;
        }

        if(pauseTimer < 1.0f)
        {
            pauseTimer += Time.deltaTime;
        }
        else
        {
            pauseTimer = 1.0f;
        }

        if(fadeOut == false && pauseTimer == 1.0f)
        {
            if (fade.material.color.a > 0)
            {
                fade.material.color = Color.Lerp(fade.material.color, transparent, Time.deltaTime * 5.0f);
            }
            else
            {
                fade.material.color = transparent;
            }
        }
    }
}
