using UnityEngine;

public class Coin : MonoBehaviour
{
    public Sound collectSound;
    public Sound[] collectDialogue;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            int randomChoice = Random.Range(0, collectDialogue.Length);

            AudioManager.Instance.PlaySound(collectSound);
            AudioManager.Instance.PlaySound(collectDialogue[randomChoice]);


            //tell game coin was collected
            UIManager.Instance.skillTree.coins++;

            //destroy coin
            Destroy(gameObject);
        }
    }
}
