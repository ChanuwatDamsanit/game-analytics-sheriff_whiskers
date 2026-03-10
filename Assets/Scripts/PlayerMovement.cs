using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d; //private variable

    Vector2 moveInput; //for walk with addforce

    //Walk left-right
    float move; //store input from player
    [SerializeField] float speed;

    //Jump
    [SerializeField] float jumpForce;

    public int playerHp;
    public int coinCount = 0;

    [SerializeField] GameManager gameManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coinCount = 0;
    }

    void Update()
    {
        /*//Walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);*/

        //Walk left-right
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        //jump
       if (Input.GetButtonDown("Jump"))
       {
           rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
           Debug.Log("Jump"); //for debugging
       }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHp -= 1;
            Destroy(other.gameObject);

            if (playerHp <= 0)
            {
                Debug.Log("Game Over!");
                gameManager.GameOver();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WinTrigger"))
        {
            Debug.Log("Win");
            gameManager.GameWin();
        }
    }
}
