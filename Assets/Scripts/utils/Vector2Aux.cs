

using UnityEngine;

public class Vector2Aux
{
    private float x;
    private float y;

    public Vector2Aux()
    {

    }
    public Vector2Aux(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 convertToVector2()
    {
        return new Vector2(x, y);
    }
}
