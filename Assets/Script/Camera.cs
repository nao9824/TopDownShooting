using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    PlayerDirection playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerDirection = GetComponent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
