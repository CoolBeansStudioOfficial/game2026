using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Audio/New Sound")]
public class Sound : ScriptableObject
{
    public string description;
    public AudioClip audioClip;
    public float volume;
    public float pitchRandomRange;
    public bool isSpatial = true;
}
