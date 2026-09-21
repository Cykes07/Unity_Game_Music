using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float offsetX = 4f;

    void LateUpdate()
    {
        var p = transform.position;
        p.x = target.position.x + offsetX;
        transform.position = p;
    }
}
