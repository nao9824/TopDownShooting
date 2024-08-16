using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;
    Rigidbody rb;

    GameObject gun;
    [SerializeField]
    public bool isHaveGun;

    // Start is called before the first frame update
    void Start()
    {

        speed = 15.0f;
        rb = GetComponent<Rigidbody>();
        gun = GameObject.FindGameObjectWithTag("Gun");
        isHaveGun = false;
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            collision.gameObject.transform.parent=gameObject.transform;
            collision.gameObject.transform.localPosition = new Vector3 (collision.gameObject.transform.localPosition.x, collision.gameObject.transform.localPosition.y+0.5f, collision.gameObject.transform.localPosition.z);
            Quaternion GunRotation = collision.transform.rotation;
            GunRotation = new Quaternion(collision.transform.localRotation.x, collision.transform.rotation.y, collision.transform.rotation.z, collision.transform.rotation.w) ;
            collision.transform.rotation = GunRotation;
            isHaveGun =true;
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * speed;
        }

        if(Input.GetMouseButtonDown(0) && isHaveGun)
        {
            Debug.Log("Œ‚‚Á‚½");

        }
    }

    
}
