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
    public ParticleSystem expSystem;
    public ParticleSystem DirtSystem;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    private AudioSource asPlayer;

    // Start is called before the first frame update
    void Start()
    {
        RIGbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        asPlayer = GetComponent<AudioSource>();
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
            DirtSystem.Stop();
            asPlayer.PlayOneShot(JumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
            DirtSystem.Play();
        }
       
       else if (collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Game Over!!!!");
            GameOver = true;
            Animator.SetBool("Death_b", true);
            Animator.SetInteger("Death_int", 2);
            expSystem.Play();
            DirtSystem.Stop();
            asPlayer.PlayOneShot(CrashSound, 1.0f);
        }
    }



}
