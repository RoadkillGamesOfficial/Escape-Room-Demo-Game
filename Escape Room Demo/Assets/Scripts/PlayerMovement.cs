using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    private float moveSpeed = 0.35f;
    void FixedUpdate()
    {
        //Movement bounding
        float verticalMultiplier = ((Input.GetAxis("Vertical") < 0 && player.position.z > 63) || (Input.GetAxis("Vertical") > 0 && player.position.z < 235)) ? Input.GetAxis("Vertical") : 0;
        float horizontalMultiplier = ((Input.GetAxis("Horizontal") < 0 && player.position.x > -80) || (Input.GetAxis("Horizontal") > 0 && player.position.x < 80)) ? Input.GetAxis("Horizontal") : 0;
        //Resolution multiplier for consistency across resolutions
        int referenceWidth = 723, referenceHeight = 407;
        float heightMultiplier = Screen.height/referenceHeight;
        float widthMultiplier = Screen.width/referenceWidth;
        player.position = new Vector3(player.position.x + horizontalMultiplier * moveSpeed * widthMultiplier, player.position.y, player.position.z + verticalMultiplier * moveSpeed * heightMultiplier);
    }
}
