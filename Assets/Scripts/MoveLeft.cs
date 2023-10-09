using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed;
    private Vector3 DeleteLimit;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 DeleteLimit = new Vector3(-20, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(Vector3.left * Time.deltaTime * Speed);

        if (transform.position == DeleteLimit)
        {
            Destroy(gameObject);
        }
    }
}
