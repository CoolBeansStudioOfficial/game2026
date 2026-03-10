using System.Collections;
using UnityEngine;

public class BoxmanIcon : MonoBehaviour
{
    new public RectTransform transform;
    public float animationSpeed;

    Vector2 baseSize;

    void Start()
    {
        baseSize = transform.sizeDelta;
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (true)
        {
            while (transform.sizeDelta.x > baseSize.x * 0.95f)
            {
                print("skibidi rizz");
                float speed = Time.deltaTime * animationSpeed;

                //shrink horizontally, grow vertically
                transform.sizeDelta = new(transform.sizeDelta.x - speed, transform.sizeDelta.y + speed);

                yield return new WaitForEndOfFrame();
            }

            while (transform.sizeDelta.x < baseSize.x)
            {
                float speed = Time.deltaTime * animationSpeed;

                //shrink horizontally, grow vertically
                Vector2 newSize = Vector2.MoveTowards(transform.sizeDelta, baseSize, speed);
                transform.sizeDelta = newSize;

                yield return new WaitForEndOfFrame();
            }
        }
        

        
    }
}
