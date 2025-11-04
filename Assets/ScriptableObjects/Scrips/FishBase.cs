using System.Collections.Specialized;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "FishBase", menuName = "Scriptable Objects/FishBase")]
public class FishBase : ScriptableObject
{
    public FoodType FoodType;
    public FishData Stats;
    public FishState CurrentState;

}
[System.Serializable]
public struct FishData
{
    public int Health;
    public float Speed;
}
public enum FoodType
{
    PELLETS = 0,
    GUPPY
}

public enum FishState
{ 
    IDLE = 0,
    WANDER


}

