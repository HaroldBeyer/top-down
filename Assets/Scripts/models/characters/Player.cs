using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int playerNumber;
    private Vector2 movement;
    private string[] keyNames = new string[4];
    protected Pistol pistol;
    protected MachineGun machineGun;
    protected SilencedPistol silencedPistol;
    public int[] ammo = new int[3];
    [HideInInspector]
    public int gunNumber = 0;
    public Transform firePoint;
    [SerializeField]
    protected GameObject pistolBullet;
    [SerializeField]
    protected GameObject machineGunBullet;
    [SerializeField]
    protected GameObject silencedBullet;

    protected PlayerState state;





    private void Start()
    {
        state = new PlayerState(this);
        rgdb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = rgdb.position;
        ChangeStance(PlayerStances.standing);
        rgdb.freezeRotation = true;
        rotation = rgdb.rotation;
        keyNames[0] = playerNumber == 0 ? "Horizontal" : "Horizontal" + playerNumber.ToString();
        keyNames[1] = playerNumber == 0 ? "Vertical" : "Vertical" + playerNumber.ToString();
        keyNames[2] = playerNumber == 0 ? "Fire" : "Fire" + playerNumber.ToString();
        keyNames[3] = playerNumber == 0 ? "Switch" : "Switch" + playerNumber.ToString();
        machineGun = new MachineGun(machineGunBullet);
        pistol = new Pistol(pistolBullet);
        silencedPistol = new SilencedPistol(silencedBullet);
        ammo = new int[3] { 500, 400, 303 };
    }

    private void FixedUpdate()
    {
        movement.x = -Input.GetAxis(keyNames[0]);
        movement.y = Input.GetAxis(keyNames[1]);

        if (movement.y != 0)
        {
            Move(movement);
        }
        else if (stance.currentSprite == stance.walkingSprite)
        {
            ChangeStance(PlayerStances.standing);
        }

        if (movement.x != 0)
        {
            Rotate(movement.x);
        }

        this.state.CheckTime();
    }

    private void LateUpdate()
    {
        if (this.state.state == PlayerStates.roaming)
        {
            if (Input.GetButton(keyNames[2]))
            {
                PrepareToShoot();
            }
            if (Input.GetButtonDown(keyNames[3]))
                SwitchGun();
        }
    }

    protected void PrepareToShoot()
    {
        Tuple<PlayerStances, Gun> SelectedGun = SelectGun();
        print(this.state.remainingTime);
        print(this.state.state);
        if (this.state.state == PlayerStates.roaming)
        {
            if (SelectedGun.Item2.HasAmmo())
            {
                ChangeStance(SelectedGun.Item1);
                SelectedGun.Item2.Shoot(firePoint);
            }
            else if (ammo[gunNumber] > 0)
            {
                ChangeStance(PlayerStances.reloading);
                ammo[gunNumber] = SelectedGun.Item2.Reload(ammo[gunNumber]);
                this.state.SetState(PlayerStates.reloading);
            }
        }
    }

    private Tuple<PlayerStances, Gun> SelectGun()
    {
        switch (gunNumber)
        {
            case 0:
                return Tuple.Create(PlayerStances.fire_pistol, (Gun)pistol);
            case 1:
                return Tuple.Create(PlayerStances.fire_silenced, (Gun)silencedPistol);
            default:
                return Tuple.Create(PlayerStances.fire_machine, (Gun)machineGun);
        }
    }

    private void SwitchGun()
    {
        if (gunNumber < 2)
            gunNumber++;
        else
            gunNumber = 0;
    }

    public void CancelShooting()
    {
        print("Cancelled!");
        CancelInvoke("PrepareToShoot");
    }
}
