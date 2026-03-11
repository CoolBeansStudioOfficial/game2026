using System.Runtime.InteropServices;
using UnityEngine;

public class BoxmanKiller : MonoBehaviour
{
    public AudioSource audioSource;

    public float moveSpeed;

    void OnEnable()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //move killer forward
        transform.position = new(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void RefreshPage();
#endif

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.canOpenSkillTree = false;
            RefreshPage();
        }
    }
}
