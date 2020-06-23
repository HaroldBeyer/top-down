using UnityEngine;



public class Utils
{
    public static Vector3 invertVector3(Vector3 vector)
    {
        vector.x = -vector.x;
        vector.y = -vector.y;
        vector.z = -vector.z;
        return vector;
    }

    public static Vector2 invertVector2(Vector2 vector)
    {
        vector.x = -vector.x;
        vector.y = -vector.y;
        return vector;
    }
    public static float limitRotation(float rotation)
    {
        if (rotation > 360 || rotation < -360)
        {
            return 0f;
        }

        return rotation;
    }
}