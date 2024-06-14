using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childMouv : MonoBehaviour
{
    public GameObject ptnA;
    public GameObject ptnB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = ptnB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == ptnB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2 (-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == ptnB.transform)
        {
            currentPoint = ptnA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == ptnA.transform)
        {
            currentPoint = ptnB.transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ptnA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(ptnB.transform.position, 0.5f);
        Gizmos.DrawLine(ptnA.transform.position, ptnB.transform.position);

    }
}

/*  private void OnCollisionEnter2D(Collision2D other)
      {
          if (other.gameObject.CompareTag("Ground"))
          {
              Vector3 normal = other.GetContact(0).normal;
              if (normal == Vector3.up)
              {
                  grounded = true;
              }

          }
      }
      private void OnCollisionExit2D(Collision2D other)
      {
          if (other.gameObject.CompareTag("Ground"))
          {
              grounded = true;
          }
      } */