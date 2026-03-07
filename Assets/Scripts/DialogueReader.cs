using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    private static DialogueReader _instance;
    public static DialogueReader Instance { get { return _instance; } }

    private void Awake()
    {
        //singleton initialization
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public GameObject panel;
    public TMP_Text text;

    public float timeBetweenChars;

    public bool playerLocked = false;

    public IEnumerator ReadDialogue(string dialogue, bool lockPlayer = false)
    {
        panel.SetActive(true);
        playerLocked = lockPlayer;

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

        yield return new WaitForSeconds(2);

        panel.SetActive(false);
        playerLocked = false;

    }

}
