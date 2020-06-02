using UnityEngine;

public class Pistol : Gun
{
    public Pistol(GameObject bulletPrefab)
    {
        this.cartridge_size = 12;
        this.current_cartridge = 0;
        this.bulletPrefab = bulletPrefab;
    }
}

//2