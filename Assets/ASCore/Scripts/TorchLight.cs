using UnityEngine;
using System.Collections;

public class TorchLight : MonoBehaviour {

    public GameObject myFire;
    bool foundTorchScene = false;

    void Update()
    {
        if (myFire != null && GameObject.Find("TorchSceneNode") != null && foundTorchScene == false)
        {
            foundTorchScene = true;
            myFire.SetActive(false);
        }
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Torch>() != null)
        {
            myFire.SetActive(true);
        }
    }
}
