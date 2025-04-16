using UnityEngine;

public class InputOutputConnection : MonoBehaviour
{
    //Set up the wire and anchor its start to the origin it was called from
    public static void getWire(LineRenderer wire, Transform originPort)
    {
        if(!GameManager.wireHeld)
        {
            //Set wire to have 2 tracked positions to draw between
            wire.positionCount = 2;
            //Set origin port to be the wire origin
            wire.SetPosition(0, originPort.position);
        }
        GameManager.wireHeld = true;
    }
    //Set the wire endpoint to the player position
    public static void followPlayer(LineRenderer wire, Transform playerPos)
    {
        //Set wire endpoint to player position
        wire.SetPosition(1, playerPos.position);
    }
    //Set the wire to connect to the input it was called from if possible, return if this was successful
    public static bool setWire(LineRenderer wire, Transform inputPort)
    {
        if(GameManager.wireHeld)
        {
            wire.SetPosition(1, inputPort.position);
            GameManager.wireHeld = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
