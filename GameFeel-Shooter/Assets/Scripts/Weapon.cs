using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] SpriteRenderer gun;
    [SerializeField] GameObject aim;
    [SerializeField] Transform muzzle;

    [SerializeField] Rigidbody2D bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        gun.flipY = dir.x > 0;

        float angle = Vector2.SignedAngle(Vector2.left, dir);

        gun.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Fire()
    {

        Rigidbody2D bulletRb = Instantiate(bullet, muzzle.position, gun.transform.rotation);
        bulletRb.linearVelocity = bulletRb.transform.right * 10;
    }
}
