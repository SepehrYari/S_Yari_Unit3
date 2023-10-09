using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed;
    private PlayerController GameOverVar;
    private float leftBounds = -10;

    // Start is called before the first frame update
    void Start()
    {
        GameOverVar = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverVar.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        if (gameObject.transform.position.x < leftBounds && gameObject.CompareTag("Obsticle"))
        {
            Destroy(gameObject);
        }

    }
}
