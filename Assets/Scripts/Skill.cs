using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/New Skill")]
public class Skill : ScriptableObject
{
    public string description;
    public int coins;
}
