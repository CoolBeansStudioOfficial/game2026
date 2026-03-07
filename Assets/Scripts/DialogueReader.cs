using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    public TMP_Text text;

    public float timeBetweenChars;

    public IEnumerator ReadDialogue(string dialogue)
    {
        var chars = dialogue.ToCharArray();

        string currentChars = string.Empty;
        for (int i = 0; i < chars.Length; i++)
        {
            currentChars += chars[i];
            text.SetText(currentChars);

            yield return new WaitForSeconds(timeBetweenChars);

            //if player presses space, skip to end
            if (Input.GetKey(KeyCode.Space))
            {
                text.SetText(dialogue);
                break;
            }
        }

        
        
    }

}
