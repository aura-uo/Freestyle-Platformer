using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Vector2 EnemySpeed = new Vector2(-3, 0);
    private Rigidbody2D RigidBod;
    private SpriteRenderer Sprite;

    void Start()
    {
        RigidBod = GetComponent<Rigidbody2D>();
        RigidBod.velocity = EnemySpeed;
        Sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Sprite.flipX = RigidBod.velocity.x > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("EnemyBarrier"))
        {
            RigidBod.velocity *= -1;
        }
    }
}
