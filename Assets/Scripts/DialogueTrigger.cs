using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogue;
    public bool oneTimeTrigger;
    public bool stopPlayer;
    public Sound activationSound;

    bool alreadyTriggered = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (alreadyTriggered) return;

        if (collider.CompareTag("Player"))
        {
            //read the dialogue
            UIManager.Instance.dialogueReader.ReadDialogue(dialogue, stopPlayer);

            //play sound
            if (activationSound != null) AudioManager.Instance.PlaySound(activationSound);
        }

        if (oneTimeTrigger) alreadyTriggered = true;
    }
}
