using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool oneTimeTrigger;
    public GameObject toActivate;
    public Sound activationSound;

    bool alreadyTriggered = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (alreadyTriggered) return;

        if (collider.CompareTag("Player"))
        {
            if (toActivate != null) toActivate.SetActive(true);
            if (activationSound != null) AudioManager.Instance.PlaySound(activationSound);
        }

        if (oneTimeTrigger) alreadyTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (alreadyTriggered) return;
        if (toActivate != null) toActivate.SetActive(false);
    }
}
