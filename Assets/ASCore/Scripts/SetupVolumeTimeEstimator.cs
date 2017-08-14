using UnityEngine;
using System.Collections;

public class SetupVolumeTimeEstimator : MonoBehaviour {

    private SetupVolume[] vols;
    public SetupVolume[] orderVols;

    public float levelTimeEstimate = 0.0f;

    private float distanceEstimate = 0.0f;

    private int[] setupNumbers;

    //private int currentSetup = 1;

    private bool collectVols = false;
    private bool finishDistCheck = false;

    void Update()
    {
        if (finishDistCheck != true)
        {
            if (collectVols != true)
            {
                SetupVolume[] getVols = GameObject.FindObjectsOfType<SetupVolume>();

                vols = new SetupVolume[getVols.Length];

                setupNumbers = new int[getVols.Length];

                orderVols = new SetupVolume[getVols.Length];

                for (int i = 0; i < getVols.Length; i++)
                {
                    vols[i] = getVols[i];

                    if (vols[i] == null)
                    {
                        print("ERROR COLLECTING SETUP VOLUMES");
                        return;
                    }
                }

                for (int i = 0; i < vols.Length; i++)
                {
                    setupNumbers[i] = vols[i].setupNum;

                    orderVols[vols[i].setupNum - 1] = vols[i];

                    if (i == vols.Length - 1)
                        collectVols = true;
                }
            }
            else
            {
                for (int i = 0; i < orderVols.Length; i++)
                {
                    if (i > 0 && i != orderVols.Length)
                    {
                        float dist = 0.0f;

                        dist = Vector3.Distance(orderVols[i - 1].gameObject.transform.position, orderVols[i].gameObject.transform.position);

                        levelTimeEstimate = levelTimeEstimate + orderVols[i -1].timeEstimate;

                        //print(orderVols[i].timeEstimate);

                        //print(dist);

                        if(dist != 0)
                        {
                            distanceEstimate = distanceEstimate + (dist / 4);
                        }
                        else
                        {
                            distanceEstimate = 0;
                        }

                        //print("DISTANCE: " + dist / 4);
                    }

                    if (i == orderVols.Length -1)
                    {
                        distanceEstimate += orderVols[orderVols.Length -1].timeEstimate;

                        levelTimeEstimate += distanceEstimate;

                        finishDistCheck = true;
                    }
                }
            }
        }
    }
}