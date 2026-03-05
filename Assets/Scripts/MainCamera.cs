using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float followSpeed;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        newPosition.z = transform.position.z;

        transform.position = newPosition;
    }
}
