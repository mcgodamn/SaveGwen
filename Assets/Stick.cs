using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public bool isStick;

    public float distance;

    Collider2D stickThing;

    Vector2 relative;

    SpringJoint2D joint2D;

    // Start is called before the first frame update
    void Start()
    {
        joint2D = GetComponent<SpringJoint2D>();
        joint2D.frequency = GameManager.instance.setting.webJointFreq;
        joint2D.dampingRatio = GameManager.instance.setting.webJointDump;
        distance = GameManager.instance.setting.webDistance;
    }

    void FixedUpdate()
    {
        joint2D.distance = distance;
        if (stickThing)
        {
            stickThing.transform.position = (Vector2)transform.position + relative;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStick) return;
        if (!col.CompareTag("gwen")) return;

        stickThing = col;
        relative = transform.position - col.transform.position;
        isStick = false;
        WebShooter.instance.isShooting = false;
    }
}
