using UnityEngine;

public static class CameraEx
{
    public static bool IsObjectVisible(this UnityEngine.Camera @this, Collider renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
    }
}