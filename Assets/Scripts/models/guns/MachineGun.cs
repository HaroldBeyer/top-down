using UnityEngine;
public class MachineGun : Gun
{
    public MachineGun(GameObject bulletPrefab)
    {
        this.cartridge_size = 32;
        this.current_cartridge = 0;
        this.bulletPrefab = bulletPrefab;
    }
}


//1