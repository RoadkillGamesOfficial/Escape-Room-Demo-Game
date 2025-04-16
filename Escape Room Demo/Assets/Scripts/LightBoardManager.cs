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
        if(GameManager.blueWire)
        {
            blueLight.GetComponentInChildren<Light>().enabled = true;
        }
        if(GameManager.redWire)
        {
            redLight.GetComponentInChildren<Light>().enabled = true;
        }
        if(GameManager.yellowWire)
        {
            yellowLight.GetComponentInChildren<Light>().enabled = true;
        }
    }
}
