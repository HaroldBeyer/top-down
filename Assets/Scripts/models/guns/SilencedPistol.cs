using UnityEngine;
public class SilencedPistol : Gun
{
    public SilencedPistol(GameObject bulletPrefab)
    {
        this.cartridge_size = 8;
        this.current_cartridge = 0;
        this.bulletPrefab = bulletPrefab;
        this.fireRate = 0.4f;
    }

    public new void Shoot(Transform firePoint)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var rotation = firePoint.rotation;
            Quaternion[] listRotations = new Quaternion[3] { rotation, rotation, rotation };
            // listRotations[0].x += Random.RandomRange(-0.01, 0.01);
            GameObject bullet = Instantiate(this.bulletPrefab, firePoint.position, firePoint.rotation);
            // GameObject bullet1 = Instantiate(this.bulletPrefab, firePoint.position, firePoint.rotation.);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Utils.invertVector3(firePoint.up), ForceMode2D.Impulse);
            current_cartridge--;
        }
    }
}

//4

/*
            var pelletRot = transform.rotation;
            pelletRot.x += Random.Range(-spreadFactor, spreadFactor);
            pelletRot.y += Random.Range(-spreadFactor, spreadFactor);
            pellet = Instantiate(pelletPrefab, transform.position, pelletRot);
            pellet.velocity = transform.forward*pelletSpeed;
*/
