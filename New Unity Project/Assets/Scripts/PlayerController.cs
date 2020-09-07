using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed= 10f;
    public float movement = 0f;
    public float jumpSpeed = 8.5f;
    private Rigidbody2D rb;
    private bool onGround ;
    private int JumpNumber;
    public float offset;
    public Vector3 respawnPoint;
    private LevelManager gameLevelManager;
    public float leftPlayerLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
 
        if (movement>0f)
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            rb.transform.Rotate(0f,0f,-5f,Space.Self);

        }
        else if( movement < 0f)
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            rb.transform.Rotate(0f, 0f, 5f, Space.Self);

        }
        if (Input.GetButtonDown("Jump") && onGround && (JumpNumber == 0 || JumpNumber ==1))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            JumpNumber += 1;
        }
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, leftPlayerLimit, 1000f),
            transform.position.y
            );


    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            if(JumpNumber == 1)
            {
                onGround = true;
            }
            else if(JumpNumber == 0)
            {
                JumpNumber += 1;
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = true;
            JumpNumber = 0;
        }
        if (col.CompareTag("FallDetector"))
        {
            gameLevelManager.Respawn();
        }
        if (col.CompareTag("Checkpoint"))
        {
            respawnPoint = col.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            onGround = true;
            JumpNumber = 0;
        }
    }
}
