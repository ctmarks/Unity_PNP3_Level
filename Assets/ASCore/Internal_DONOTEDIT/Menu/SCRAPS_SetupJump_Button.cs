using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCRAPS_SetupJump_Button : MonoBehaviour {

    private bool collectedSetups = false;
    private SetupVolume myVol;
    public int setupNum = 0;
    public Text buttonText;
    public Button but;

	// Update is called once per frame
	void Update () {

        if(collectedSetups != true)
        {
            //collect our setup
            SetupVolumeTimeEstimator sVol = GameObject.FindObjectOfType<SetupVolumeTimeEstimator>();
            if(sVol != null)
            {
                if(setupNum - 1 < sVol.orderVols.Length)
                {
                    myVol = sVol.orderVols[setupNum - 1];

                    buttonText.text = "<b>Setup " + setupNum + "</b> ("+ sVol.orderVols[setupNum-1].timeEstimate+") \n"+ sVol.orderVols[setupNum-1].msgBody+"";

                    GameObject nextButton = Instantiate(gameObject, transform.position, transform.rotation);
                    nextButton.GetComponent<SCRAPS_SetupJump_Button>().setupNum = setupNum + 1;
                    RectTransform newRect = nextButton.GetComponent<RectTransform>();
                    RectTransform myRect = GetComponent<RectTransform>();
                    newRect.parent = myRect.parent;
                    newRect.sizeDelta = myRect.sizeDelta;
                    newRect.anchorMin = myRect.anchorMin;
                    newRect.anchorMax = myRect.anchorMax;
                    newRect.anchoredPosition = myRect.anchoredPosition;
                    newRect.Translate(Vector3.down * 75.0f);
                }
                else
                {
                    buttonText.text = "Error - No Setup Volume";
                    but.interactable = false;
                }
            }
            else
            {
                buttonText.text = "Error - No Time Estimator";
                but.interactable = false;
            }

            collectedSetups = true;
        }
		
	}

    public void TeleportToSetup()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = myVol.transform.position;
    }
}
