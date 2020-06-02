using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    //maximum capacity of the gun's ammo
    protected int cartridge_size;
    //how many bullets are left in the gun's cartridge
    protected int current_cartridge;
    //type of bullet
    protected GameObject bulletPrefab;



    public int Reload(int ammo)
    {
        var amountToReload = cartridge_size - current_cartridge;
        if (ammo > amountToReload)
        {
            current_cartridge += amountToReload;
            return ammo - amountToReload;
        }
        else
        {
            current_cartridge += ammo;
            return 0;
        }
    }

    public void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(this.bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Utils.invertVector3(firePoint.up), ForceMode2D.Impulse);
        current_cartridge--;
    }

    public bool HasAmmo()
    {
        if (this.current_cartridge > 0)
            return true;
        return false;
    }
}