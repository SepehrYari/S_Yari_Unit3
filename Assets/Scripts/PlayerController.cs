using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RIGbody;
    public float GravityValue;
    public float Jumpforce = 10;
    private bool OnGround = true;
    public bool GameOver = false;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        RIGbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        Physics.gravity *= GravityValue;

    }

    // Update is called once per frame
    void Update()
    {
        bool spaceButton = Input.GetKeyDown(KeyCode.Space);
        if (spaceButton && OnGround && !GameOver)
        {
            RIGbody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            OnGround = false;
            Animator.SetTrigger("Jump_trig");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
       
       else if (collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game Over!!!!");
            GameOver = true;
            Animator.SetBool("Death_b", true);
            Animator.SetInteger("Death_int", 2);
        }
    }



}
