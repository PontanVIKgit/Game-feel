using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3f;

    Rigidbody2D rb;
    [SerializeField] SpriteRenderer playerSprite;
    Vector2 bounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bounds = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W) && transform.position.y < bounds.y)
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < bounds.x)
        {
            dir.x = 1;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y> -bounds.y)
        {
            dir.y = -1;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -bounds.x)
        {
            dir.x = -1;
        }

        if(dir.x > 0)
        {
            playerSprite.flipX = false;
        }
        if(dir.x < 0)
        {
            playerSprite.flipX = true;
        }

            rb.linearVelocity = dir.normalized * movementSpeed;

    }
}
