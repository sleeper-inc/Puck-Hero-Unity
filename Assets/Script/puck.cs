using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1f * Time.deltaTime ,2f *Time.deltaTime);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (transform.position.y > 11)
        {
            puckreset1();
        }
        if (transform.position.y < -9)
        {
            puckreset2();
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

    }
    private IEnumerator waitReset()
    {
        yield return new WaitForSecondsRealtime(1);
    }

    public void puckreset1()
    {
        StartCoroutine(waitReset());
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0.4f, 3f);
    }

    public void puckreset2()
    {
        StartCoroutine(waitReset());
        rb.velocity = Vector2.zero;
        transform.position = new Vector3(0.4f, -3f);
    }
}
