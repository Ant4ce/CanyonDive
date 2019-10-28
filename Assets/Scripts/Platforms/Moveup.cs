using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveup : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var campos = GetComponent<Transform> ();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Time.deltaTime * 5f * UnityEngine.Vector3.up;
        }
    }
}
