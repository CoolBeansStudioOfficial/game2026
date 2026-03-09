using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float followSpeed;

    public Transform[] backgroundImages;
    public Vector2[] offsets;
    public float parallaxMultiplier;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        //move camera
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        //move background image
        int i = 0;
        foreach (Transform image in backgroundImages)
        {
            newPosition = new(transform.position.x * parallaxMultiplier * (i + 1) + offsets[i].x, transform.position.y * parallaxMultiplier * (i + 1) + offsets[i].y, image.localPosition.z);
            image.localPosition = newPosition;

            i++;
        }
        
    }
}
