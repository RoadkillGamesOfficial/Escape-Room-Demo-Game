using UnityEngine;
public class WireManager : MonoBehaviour
{
    //Make an enum to determine if the port is an in or out and store this object's val in a var
    public enum PortType {Output, Input};
    public PortType portType;
    //Store a single static reference across wires to the player position
    public static Transform playerPos;
    //Stores a single static list of all wires
    public static LineRenderer [] wires = new LineRenderer[4];

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        wires[0] = GameObject.Find("GreenWire").GetComponent<LineRenderer>();
        wires[1] = GameObject.Find("BlueWire").GetComponent<LineRenderer>();
        wires[2] = GameObject.Find("RedWire").GetComponent<LineRenderer>();
        wires[3] = GameObject.Find("YellowWire").GetComponent<LineRenderer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            switch(this.portType)
            {
                case PortType.Output:
                    switch(this.gameObject.tag)
                    {
                        case "Green":
                            if(!GameManager.greenWire && !GameManager.wireHeld)
                            {
                                InputOutputConnection.getWire(wires[0], this.gameObject.transform);
                                GameManager.holdGreen = true;
                            }
                            break;
                        case "Blue":
                            if(!GameManager.blueWire && !GameManager.wireHeld)
                            {
                                InputOutputConnection.getWire(wires[1], this.gameObject.transform);
                                GameManager.holdBlue = true;
                            }
                            break;
                        case "Red":
                            if(!GameManager.redWire && !GameManager.wireHeld)
                            {
                                InputOutputConnection.getWire(wires[2], this.gameObject.transform);
                                GameManager.holdRed = true;
                            }
                            break;
                        case "Yellow":
                            if(!GameManager.yellowWire && !GameManager.wireHeld)
                            {
                                InputOutputConnection.getWire(wires[3], this.gameObject.transform);
                                GameManager.holdYellow = true;
                            }
                            break;
                    }
                    break;
                case PortType.Input:
                    switch(this.gameObject.tag)
                    {
                        case "Green":
                            if(GameManager.holdGreen)
                                if(InputOutputConnection.setWire(wires[0], this.gameObject.transform))
                                {
                                    GameManager.greenWire = true;
                                    GameManager.holdGreen = false;
                                }
                            break;
                        case "Blue":
                            if(GameManager.holdBlue)
                                if(InputOutputConnection.setWire(wires[1], this.gameObject.transform))
                                {
                                    GameManager.blueWire = true;                                    
                                    GameManager.holdBlue = false;
                                }
                            break;
                        case "Red":
                            if(GameManager.holdRed)
                                if(InputOutputConnection.setWire(wires[2], this.gameObject.transform))
                                {
                                    GameManager.redWire = true;                                    
                                    GameManager.holdRed = false;
                                }
                            break;
                        case "Yellow":
                            if(GameManager.holdYellow)
                                if(InputOutputConnection.setWire(wires[3], this.gameObject.transform))
                                {
                                    GameManager.yellowWire = true;                                    
                                    GameManager.holdYellow = false;
                                }
                            break;
                    }
                    break;
            }
        }
    }
    void Update()
    {
        if(GameManager.holdGreen)
            InputOutputConnection.followPlayer(wires[0], playerPos);
        if(GameManager.holdBlue)
            InputOutputConnection.followPlayer(wires[1], playerPos);
        if(GameManager.holdRed)
            InputOutputConnection.followPlayer(wires[2], playerPos);
        if(GameManager.holdYellow)
            InputOutputConnection.followPlayer(wires[3], playerPos);
    }
}
