using UnityEngine;
public class WireManager : MonoBehaviour
{
    public Transform playerPos;
    private Transform originPort;
    private LineRenderer wire;

    void Start()
    {
        wire = gameObject.GetComponent<LineRenderer>();
        wire.positionCount = 2;
        originPort = gameObject.GetComponentInParent<Transform>();
        wire.SetPosition(0, originPort.position);
    }
    void Update()
    {
        wire.SetPosition(1, playerPos.position);
    }
}
