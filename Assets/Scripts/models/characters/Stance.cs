using UnityEngine;

[System.Serializable]
public class Stance
{
    public Sprite currentSprite { get; private set; }
    [SerializeField]
    public Sprite standingSprite;
    [SerializeField]
    public Sprite walkingSprite;
    [SerializeField]
    public Sprite firePistolSprite;
    [SerializeField]
    public Sprite fireSilencedSprite;
    [SerializeField]
    public Sprite fireMachineGunSprite;
    [SerializeField]
    public Sprite reloadingSprite;

    public void changeStance(PlayerStances stance)
    {
        switch (stance)
        {
            case PlayerStances.standing:
                currentSprite = standingSprite;
                break;
            case PlayerStances.walking:
                currentSprite = walkingSprite;
                break;
            case PlayerStances.fire_pistol:
                currentSprite = firePistolSprite;
                break;
            case PlayerStances.fire_silenced:
                currentSprite = fireSilencedSprite;
                break;
            case PlayerStances.fire_machine:
                currentSprite = fireMachineGunSprite;
                break;
            case PlayerStances.reloading:
                currentSprite = reloadingSprite;
                break;
        }
    }

    public bool equalsToStandingSprite(Sprite sprite)
    {

        if (sprite == standingSprite)
        {
            return true;
        }
        return false;
    }
}