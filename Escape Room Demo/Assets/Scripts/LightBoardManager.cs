using UnityEngine;

public class LightBoardManager : MonoBehaviour
{
    public GameObject greenLight, blueLight, redLight, yellowLight;
    void Update()
    {
        if(GameManager.greenWire)
        {
            greenLight.GetComponentInChildren<Light>().enabled = true;
        }
    }
}
