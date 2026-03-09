using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float followSpeed;

    public Transform backgroundImage;
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
        newPosition = new(transform.position.x * parallaxMultiplier, transform.position.y * parallaxMultiplier, backgroundImage.localPosition.z);
        backgroundImage.localPosition = newPosition;
    }
}
