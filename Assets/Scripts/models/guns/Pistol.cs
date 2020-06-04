using UnityEngine;

public class Pistol : Gun
{
    public Pistol(GameObject bulletPrefab)
    {
        this.cartridge_size = 12;
        this.current_cartridge = 0;
        this.bulletPrefab = bulletPrefab;
        this.fireRate = 0.3f;
    }
}

//2