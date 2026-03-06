using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource source;

    public Transform followTarget;

    private void Update()
    {
        if (followTarget != null)
        {
            transform.position = followTarget.position;
        }
    }

    public void PlaySound(Sound sound)
    {
        source.clip = sound.audioClip;

        if (sound.isSpatial) source.spatialBlend = 1;
        else source.spatialBlend = 0;

        source.pitch = 1f;
        if (sound.pitchRandomRange != 0f) RandomizePitch(sound.pitchRandomRange);

        source.Play();
    }

    public void SetFollowTarget(Transform target = null)
    {
        followTarget = target;
        //move sound player to target right away for good measure
        if (target != null)
        {
            transform.position = followTarget.position;
        }
    }

    void RandomizePitch(float range)
    {
        source.pitch = 1f + Random.Range(-range, range);
    }
}
