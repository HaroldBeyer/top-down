using UnityEngine;
public class SilencedPistol : Gun
{
    public SilencedPistol(GameObject bulletPrefab)
    {
        this.cartridge_size = 8;
        this.current_cartridge = 0;
        this.bulletPrefab = bulletPrefab;
    }
}

//4