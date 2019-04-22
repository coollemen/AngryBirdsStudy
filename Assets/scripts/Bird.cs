using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isClicked = false;

    public float maxDistance = 1.2f;

    public Transform rightPos;

    public Rigidbody2D rig;

    public SpringJoint2D sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpringJoint2D>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position-=new Vector3(0,0,Camera.main.transform.position.z);
            if (Vector3.Distance(transform.position, rightPos.position) > maxDistance)
            {
                var uv = (transform.position - rightPos.position).normalized;
                transform.position = uv * maxDistance;
            }
        }
    }

    private void OnMouseDown()
    {
        isClicked = true;
        rig.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClicked = false;
        rig.isKinematic = false;
        Invoke("Fly",0.1f);
    }

    private void Fly()
    {
        sp.enabled = false;
    }
}
