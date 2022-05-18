using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achse : MonoBehaviour
{
    public GameObject Forward;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0) * Forward.transform.rotation;
    }
}
