using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;

    public float minSpeed = 5;

    public SpriteRenderer render;

    public Sprite hurt;

    public GameObject boom;

    public GameObject score;
    // Start is called before the first frame update
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (other.relativeVelocity.magnitude > minSpeed && other.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
        }
    }

    void Dead()
    {
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position+new Vector3(0,0.7f,0), Quaternion.identity);
        Destroy(go,2f);
    }
}