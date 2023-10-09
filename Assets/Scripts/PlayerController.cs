using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RIGbody;
    public float GravityValue;
    public float Jumpforce = 10;
    private bool OnGround;

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
        if (spaceButton && OnGround)
        {
            RIGbody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            OnGround = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        OnGround = true;
    }



}
