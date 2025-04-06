using UnityEngine;

public class InputOutputConnection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Output":
                Debug.Log("Hit " + other.gameObject.name + " output");
                break;
            case "Input":
                Debug.Log("Hit " + other.gameObject.name + " input");
                break;
        }
    }
}
