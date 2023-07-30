using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Info", menuName = "Level")]
public class LevelInfo : ScriptableObject
{
    [Header("Obstacles")]
    public Vector3[] ObstaclePositions;
    public Vector3[] ObstacleRotations;

    [Space]
    [Header("Ball")]

    public Vector3 BallPosition;
    public Vector3 BallRotation;

    [Space]
    [Header("Star")]

    public Vector3 StarPosition;
    public Vector3 StarRotation;

    [Space]
    [Header("Finish")]

    public Vector3 FinishPosition;
    public Vector3 FinishRotation;
}