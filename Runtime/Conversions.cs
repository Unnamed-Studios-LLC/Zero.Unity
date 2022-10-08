using UnityEngine;
using Zero.Game.Shared;

public static class Conversions
{
    public static Vector2Int ToUnity(this Int2 value) => new Vector2Int(value.X, value.Y);
    public static Vector3Int ToUnity(this Int3 value) => new Vector3Int(value.X, value.Y, value.Z);
    public static Vector2 ToUnity(this Vec2 value) => new Vector2(value.X, value.Y);
    public static Vector3 ToUnity(this Vec3 value) => new Vector3(value.X, value.Y, value.Z);

    public static Int2 ToZero(this Vector2Int value) => new Int2(value.x, value.y);
    public static Int3 ToZero(this Vector3Int value) => new Int3(value.x, value.y, value.z);
    public static Vec2 ToZero(this Vector2 value) => new Vec2(value.x, value.y);
    public static Vec3 ToZero(this Vector3 value) => new Vec3(value.x, value.y, value.z);
} 
