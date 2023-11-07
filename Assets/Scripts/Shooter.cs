using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;

    public void Shoot(float direction)
    {
        if(transform.localScale.x == 1)
        {
            GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            Rigidbody2D newBulletVelocity = newBullet.GetComponent<Rigidbody2D>();
            newBulletVelocity.velocity = new Vector2(fireForce * 1, newBulletVelocity.velocity.y);
        }
        else if(transform.localScale.x == -1)
        {
            GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            Rigidbody2D newBulletVelocity = newBullet.GetComponent<Rigidbody2D>();
            newBulletVelocity.velocity = new Vector2(fireForce * -1, newBulletVelocity.velocity.y);
        }   
    }

}
