using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D playerRB;
    BoxCollider2D playerCol;
    public float speed = 5f;
    public float gravity = 0.1f;
    public LayerMask floorLayer;
    public float jumpHeight = 20f;
    public float terminalAirVelocity = 1f;

    private Vector2 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {

        
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;


        if (!isGrounded())
        {
            velocity.y -= gravity;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            velocity.y = jumpHeight;
        }


        


    }
    void FixedUpdate()
    {

        if (isGrounded() && velocity.y < 0f) 
        {
            velocity.y = 0f;
        } else
        {
            velocity.y = Mathf.MoveTowards(velocity.y, terminalAirVelocity, gravity * Time.fixedDeltaTime);
        }
        
        Debug.Log(velocity.y);

        playerRB.linearVelocity = velocity;
    }


    bool isGrounded()
    {
        bool groundHit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.size, 0, Vector2.down, 0.05f, floorLayer);
        return groundHit;
    }
    void handleGravity()
    {
        var inAirGravity = gravity;
        
    }
}
    