using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class PlatformGen : MonoBehaviour
{
    public BoxCollider2D platformPrefab;
    public Rigidbody2D player;
    
    public static Transform Current;
    public static float VerticalCameraSize;    
    
    private Vector3 lastPlatformPosition;
    private Vector3 currentPlayerPosition;
    private Quaternion currentPlayerRotation;
    private float horizontalCameraSize;
    private float horizontalCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        Current = GetComponent<Transform>();
        currentPlayerPosition = Current.position;
        currentPlayerRotation = Current.rotation;
        horizontalCameraPosition = currentPlayerPosition.x;
        lastPlatformPosition = currentPlayerPosition;
        lastPlatformPosition.y = lastPlatformPosition.y - 5f;
        lastPlatformPosition.z = player.transform.position.z;
        
        var cam = GetComponent<Camera>();
        VerticalCameraSize = cam.orthographicSize;
        horizontalCameraSize = cam.aspect * VerticalCameraSize;
    }
    
    //get current position and generate Platforms in limited range above
    private void FixedUpdate()
    {
        var playerHeight = Current.position.y;
        if (lastPlatformPosition.y <= playerHeight + VerticalCameraSize + 5f)
        {
            BoxCollider2D platforms;
            Vector3 newPlatformPosition = NewPlatform(lastPlatformPosition, horizontalCameraSize, playerHeight);
            platforms = Instantiate(platformPrefab, newPlatformPosition , currentPlayerRotation) as BoxCollider2D;
        }
    }
    
    //This is the method defining the Platforms position and distance
    private Vector3 NewPlatform(Vector3 oldPlatform, float horizontalRange, float height)
    {
        Vector3 newPlatform;
        newPlatform.x = horizontalCameraPosition + Random.Range(-horizontalRange,horizontalRange);
        //defining vertical position of the platforms, based on scaling and random modifier
        var randomHeightMod = height * Random.Range(0.02f, 0.026f); 
        newPlatform.y = 9f + oldPlatform.y + (0.025f * height) + Random.Range(-randomHeightMod, randomHeightMod);
        newPlatform.z = oldPlatform.z;
        lastPlatformPosition = newPlatform;
        return newPlatform;
    }
}
