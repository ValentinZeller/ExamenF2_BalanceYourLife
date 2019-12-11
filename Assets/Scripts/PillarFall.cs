using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarFall : MonoBehaviour
{
    float timer = 10.0f;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            body.bodyType = RigidbodyType2D.Dynamic;
        }
        if (timer < -5)
        {
            Destroy(body.gameObject);
        }
    }
}
