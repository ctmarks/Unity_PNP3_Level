using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupMessageSystem : MonoBehaviour {

    public GameObject panel;
    public Text msgFrom;
    public Text msgBody;
    private bool show = false;
    private float showTime = 0;

    void Update()
    {
        if (panel.activeSelf != show)
            panel.SetActive(show);

        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
        }
        else
        {
            show = false;
        }
    }

    public void NewMessage(string from, string body, float displayTime)
    {
        //fix new lines for Windows
        body = body.Replace("/n", "\n");

        showTime = displayTime;
        msgFrom.text = from;
        msgBody.text = body;
        show = true;
    }
}
