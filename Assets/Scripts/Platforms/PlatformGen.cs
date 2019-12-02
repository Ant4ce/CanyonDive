using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class PlatformGen : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject player;
    
    public static Transform Current;
    public static float VerticalCameraSize;    
    
    private Vector3 _lastPlatformPosition;
    private Vector3 _currentPlayerPosition;
    private Quaternion _currentPlayerRotation;
    private float _horizontalCameraSize;
    private float _horizontalCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        var cam = GetComponent<Camera>();
        VerticalCameraSize = cam.orthographicSize;
        _horizontalCameraSize = cam.aspect * VerticalCameraSize;

        Current = GetComponent<Transform>();
        _currentPlayerPosition = Current.position;
        _currentPlayerRotation = Current.rotation;
        _horizontalCameraPosition = _currentPlayerPosition.x;
        _lastPlatformPosition = _currentPlayerPosition;
        _lastPlatformPosition.y -= VerticalCameraSize;
        _lastPlatformPosition.z = player.transform.position.z;
    }
    
    //get current position and generate Platforms in limited range above
    private void FixedUpdate()
    {
        var playerHeight = Current.position.y;
        if (_lastPlatformPosition.y <= playerHeight + VerticalCameraSize + 2f)
        {
            GameObject platforms;
            Vector3 newPlatformPosition = NewPlatform(_lastPlatformPosition, _horizontalCameraSize, playerHeight);
            platforms = Instantiate(platformPrefab, newPlatformPosition , _currentPlayerRotation) as GameObject;
        }
    }
    
    //This is the method defining the Platforms position and distance
    private Vector3 NewPlatform(Vector3 oldPlatform, float horizontalRange, float height)
    {
        Vector3 newPlatform;
        newPlatform.x = _horizontalCameraPosition + Random.Range(-horizontalRange,horizontalRange);
        //defining vertical position of the platforms, based on scaling and random modifier
        var randomHeightMod = height * Random.Range(0.02f, 0.026f); 
        newPlatform.y = 9f + oldPlatform.y + (0.025f * height) + Random.Range(-randomHeightMod, randomHeightMod);
        newPlatform.z = oldPlatform.z;
        _lastPlatformPosition = newPlatform;
        return newPlatform;
    }
}
