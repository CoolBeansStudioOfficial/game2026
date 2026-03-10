using System.Collections;
using UnityEngine;

public class BoxmanIcon : MonoBehaviour
{
    new public RectTransform transform;
    public float animationSpeed;
    public Vector2 animationMultipliers;

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
            float i = 0;
            while (i < 1)
            {
                transform.sizeDelta = Vector2.Lerp(baseSize, baseSize * animationMultipliers, i);

                i += Time.deltaTime * animationSpeed;
                yield return new WaitForEndOfFrame();
            }

            transform.sizeDelta = baseSize * animationMultipliers;

            i = 0;
            while (i < 1)
            {
                transform.sizeDelta = Vector2.Lerp(baseSize * animationMultipliers, baseSize, i);

                i += Time.deltaTime * animationSpeed;
                yield return new WaitForEndOfFrame();
            }

            transform.sizeDelta = baseSize;
        }        
    }
}
