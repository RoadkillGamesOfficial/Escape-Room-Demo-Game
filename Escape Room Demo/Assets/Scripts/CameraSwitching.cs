using UnityEditor.SearchService;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public Camera [] cameras = new Camera[3];
    private int cameraIndex = 0;
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            cameraIndex ++;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            cameraIndex --;
        }
        foreach(Camera cam in cameras)
        {
            cam.enabled = false;
        }
        cameraIndex = Mathf.Clamp(cameraIndex, 0, cameras.Length-1);
        cameras[cameraIndex].enabled = true;
    }
}
