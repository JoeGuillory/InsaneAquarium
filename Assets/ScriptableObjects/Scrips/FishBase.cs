using System.Collections.Specialized;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "FishBase", menuName = "Scriptable Objects/FishBase")]
public class FishBase : ScriptableObject
{
    public FoodType FoodType;
    [SerializeField]
    private FishStats _stats;
    public FishStats BaseStats => _stats;
  
}
[System.Serializable]
public struct FishStats
{
    public int Health;
    public float Speed;
}
public enum FoodType
{
    Pellets = 0,
    Fish
}