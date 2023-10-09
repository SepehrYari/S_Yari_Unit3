using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RIGbody;
    public float GravityValue;

    // Start is called before the first frame update
    void Start()
    {
        RIGbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityValue;
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceButton = Input.GetKeyDown(KeyCode.Space);
        if (spaceButton)
        {
            RIGbody.AddForce(Vector3.up * 10, ForceMode.Impulse);


        }

        
    }
}
