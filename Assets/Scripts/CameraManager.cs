using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public Transform target;
    
    public float cameraSpeed;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, -10), cameraSpeed);
    }
}
