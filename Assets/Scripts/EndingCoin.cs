using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCoin : MonoBehaviour
{
    public string endingSceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(endingSceneName, LoadSceneMode.Single);
    }
}
