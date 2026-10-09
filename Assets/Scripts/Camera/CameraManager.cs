using UnityEngine;


public class CameraManager : MonoBehaviour
{
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;
    public GameObject map;
    Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        SetTransform(cameraPosition, cameraRotation);
    }

    void SetAspect(float w, float h)
    { 
        
    }
    
    void SetTransform(Vector3 pos, Quaternion rot)
    {
        cam.transform.position = pos;
        cam.transform.rotation = rot;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
