using System.Collections;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    public Vector3 playerPosition;
    public float movement = 0f;
    public float leftCamLimit;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if(movement > 0f)
        {
           playerPosition = new Vector3(
           Mathf.Clamp(player.transform.position.x+offset, leftCamLimit, 1000f),
           transform.position.y,
           transform.position.z);
            //   playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
           transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
        else if(movement <0f)
       {
           playerPosition = new Vector3(
           Mathf.Clamp(player.transform.position.x - offset, leftCamLimit, 1000f),
           transform.position.y,
           transform.position.z);
            //     playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
           transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
       
        
        
    }
}
