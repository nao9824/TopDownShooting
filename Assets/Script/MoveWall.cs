using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    public bool isPush = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPush)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.y -= 0.5f;
            gameObject.transform.position = newPosition;
        }

    }
}
