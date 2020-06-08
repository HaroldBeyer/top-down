using UnityEngine;

[System.Serializable]

public class ObjectStance
{

    public Sprite currentSprite { get; private set; }
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite damaged;
    [SerializeField]
    private Sprite destroyed;

    public Sprite changeStance(ObjectStances stances)
    {
        switch (stances)
        {
            case ObjectStances.normal:
                this.currentSprite = normal;
                break;
            case ObjectStances.destroyed:
                this.currentSprite = destroyed;
                break;
            case ObjectStances.damaged:
                this.currentSprite = destroyed;
                break;
            default:
                throw new System.Exception();
        }
        return this.currentSprite;
    }

}