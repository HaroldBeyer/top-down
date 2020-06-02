using UnityEngine;


public interface IGun
{
    void Shoot(Transform firePoint);

    int Reload(int ammo);

    bool HasAmmo();
}