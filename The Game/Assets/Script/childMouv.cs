using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class childMouv : MonoBehaviour
{
    public string npcIdleText = "The NPC is idle.";
    public string npcWorkingText = "The NPC is working.";
    public TextMeshPro interactionText; // Assign the UI Text element in the Inspector
    // private string currentAction = "idle";
    public GameObject ptnA;
    public GameObject ptnB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public bool Idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = ptnB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Idle == true)
        {
            IdleMode();
        }
    }





    public void IdleMode()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == ptnB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == ptnB.transform)
        {
            currentPoint = ptnA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == ptnA.transform)
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
