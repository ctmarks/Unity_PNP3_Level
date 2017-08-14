using UnityEngine;

public class OnlyOneDirectionalLight : MonoBehaviour {

	void Start()
    {
        Light[] dLights = GameObject.FindObjectsOfType<Light>();

        foreach(Light l in dLights)
        {
            if(l.type == LightType.Directional)
            {
                if (l.gameObject != gameObject)
                {
                    Destroy(l.gameObject);
                    print("HUB: Removing duplicate directional lights... Only one allowed!");
                }
            }
        }
    }
}
