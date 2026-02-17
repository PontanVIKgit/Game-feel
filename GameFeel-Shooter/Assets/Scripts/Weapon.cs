using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] SpriteRenderer gunSprite;

    [SerializeField] GameObject aim;
    [SerializeField] Transform muzzle;

    [SerializeField] Rigidbody2D bullet;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
    }

    void Aim()
    {
        Vector2 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aim.transform.position = aimPos;
        Vector2 dir = (Vector2)transform.position - aimPos;

        gunSprite.flipY = dir.x > 0;

        float angle = Vector2.SignedAngle(Vector2.left, dir);

        gun.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Fire()
    {

        Rigidbody2D bulletRb = Instantiate(bullet, muzzle.position, gun.transform.rotation);
        bulletRb.linearVelocity = bulletRb.transform.right * 20;

        Destroy(bulletRb.gameObject, 5f);

        if(animator != null)
        {
            animator.Play("shoot");
        }
    }
}
