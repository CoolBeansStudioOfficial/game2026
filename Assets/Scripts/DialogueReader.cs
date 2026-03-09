using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text;

    public float timeBetweenChars;
    public int charsPerSound;
    public Sound dialogueSound;

    public void ReadDialogue(string dialogue, bool lockPlayer = false)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayDialogue(dialogue, lockPlayer));
    }

    IEnumerator DisplayDialogue(string dialogue, bool lockPlayer = false)
    {
        panel.SetActive(true);
        UIManager.Instance.playerLocked = lockPlayer;

        var chars = dialogue.ToCharArray();

        string currentChars = string.Empty;
        for (int i = 0; i < chars.Length; i++)
        {
            currentChars += chars[i];
            text.SetText(currentChars);

            if (i % charsPerSound == 0) AudioManager.Instance.PlaySound(dialogueSound);

            yield return new WaitForSeconds(timeBetweenChars);

            //if player presses space, skip to end
            if (Input.GetKey(KeyCode.Space))
            {
                text.SetText(dialogue);
                break;
            }
        }

        yield return new WaitForSeconds(2);

        panel.SetActive(false);
        UIManager.Instance.playerLocked = false;

    }

}
