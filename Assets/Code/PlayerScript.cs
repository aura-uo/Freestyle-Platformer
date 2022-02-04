using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public float PlayerSpeed = 5;
    public float JumpHeight = 7;
    private bool isGrounded = true;

    public float DashSpeed = 30;
    public float DashDuration = 0.1f;
    public float DashBreak = 0.3f;
    private float LastDash = 0;

    private bool isDashing = false;

    private Rigidbody2D RigidBod;
    private SpriteRenderer Sprite;

    void Start()
    {
        RigidBod = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Jump") == 1 && isGrounded) 
        {
            SoundManager.PlaySound("jump");
            RigidBod.velocity = new Vector2(RigidBod.velocity.x, JumpHeight);
            isGrounded = false;
        }

        if(Input.GetAxisRaw("Fire1") == 1 &&
            Time.time > LastDash + DashDuration + DashBreak && !isDashing)
        {
            SoundManager.PlaySound("dash");
            isDashing = true;
            LastDash = Time.time;
            if (Sprite.flipX)
            {
                RigidBod.velocity = new Vector2(-DashSpeed, RigidBod.velocity.y);
            } else
            {
                RigidBod.velocity = new Vector2(DashSpeed, RigidBod.velocity.y);
            } 
         
        }

        if (Time.time > LastDash + DashDuration)
        {
            isDashing = false;
            Vector2 PlayerDirection = new Vector2(PlayerSpeed * Input.GetAxis("Horizontal"), RigidBod.velocity.y);
            RigidBod.velocity = PlayerDirection;

            if (RigidBod.velocity.x < 0)
            {
                Sprite.flipX = true;
            } else if (RigidBod.velocity.x > 0)
            {
                Sprite.flipX = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.name.Contains("Goal"))
        {
            SoundManager.PlaySound("progress");
            WinPanel.SetActive(true);
            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Contains("Spike"))
        {
            Lose();
        }
        else if (collision.gameObject.name.Contains("Enemy")){
            if (isDashing)
            {
                Destroy(collision.gameObject);
                ScoreManager.AddScore(200);
            }
            else
            {
                Lose();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Coin"))
        {
            Destroy(collision.gameObject);
            ScoreManager.AddScore(100);
        }
        else if (collision.gameObject.name.Contains("DeathByFall"))
        {
            Lose();
        }
    }

    private void Lose()
    {
        SoundManager.PlaySound("lose");
        LosePanel.SetActive(true);
        Destroy(gameObject);
    }
}
