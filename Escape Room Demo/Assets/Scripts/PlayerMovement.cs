using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    private float moveSpeed = 0.80f;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = this.gameObject.transform.position;
    }
    void FixedUpdate()
    {
        //Movement bounding
        float verticalMultiplier = ((Input.GetAxis("Vertical") < 0 && player.position.z > -80) || (Input.GetAxis("Vertical") > 0 && player.position.z < 415)) ? Input.GetAxis("Vertical") : 0;
        float horizontalMultiplier = ((Input.GetAxis("Horizontal") < 0 && player.position.x > -115) || (Input.GetAxis("Horizontal") > 0 && player.position.x < 107)) ? Input.GetAxis("Horizontal") : 0;
        //Resolution multiplier for consistency across resolutions
        int referenceWidth = 723, referenceHeight = 407;
        float heightMultiplier = Screen.height/referenceHeight;
        float widthMultiplier = Screen.width/referenceWidth;
        player.position = new Vector3(player.position.x + horizontalMultiplier * moveSpeed * widthMultiplier, player.position.y, player.position.z + verticalMultiplier * moveSpeed * heightMultiplier);
    }
    public void resetPosition()
    {
        this.gameObject.transform.position = startPosition;
    }
}
