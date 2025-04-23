using System;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserManager : MonoBehaviour
{
    public float startX, endX, startZ, endZ;
    private float xDistance, zDistance;
    LineRenderer laser;
    void Start()
    {
        laser = this.gameObject.GetComponent<LineRenderer>();
        laser.positionCount = 2;
        xDistance = Math.Abs(endX - startX);
        zDistance = Math.Abs(endZ - startZ);
        if(xDistance == 0) xDistance = 0.01f;
        if(zDistance == 0) zDistance = 0.01f;
    }
    void FixedUpdate()
    {
        int directionMultiplierX = 1, directionMultiplierZ = 1;
        if(startX > endX) directionMultiplierX = -1;
        if(startZ > endZ) directionMultiplierZ = -1;
        laser.SetPosition(0, this.gameObject.transform.position + new Vector3(directionMultiplierX * Mathf.PingPong(45 * Time.time, xDistance), 0, directionMultiplierZ * Mathf.PingPong(45 * Time.time, zDistance)));
        laser.SetPosition(1, this.gameObject.transform.position + new Vector3(directionMultiplierX * Mathf.PingPong(45 * Time.time, xDistance), 100, directionMultiplierZ * Mathf.PingPong(45 * Time.time, zDistance)));
    }

    private RaycastHit hit;
    void Update()
    {
        if(Physics.Raycast(laser.GetPosition(0), Vector3.up, out hit, 100))
        {
            if(hit.collider.gameObject.name == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerMovement>().resetPosition();
            }
        }
    }
}
