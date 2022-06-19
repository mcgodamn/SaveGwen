using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwenPart : MonoBehaviour
{
    FixedJoint2D joint2D;

    // Start is called before the first frame update
    void Start()
    {
        joint2D = GetComponent<FixedJoint2D>();
        if (joint2D)
        {
            joint2D.frequency = GameManager.instance.setting.gwenJointFreq;
            joint2D.dampingRatio = GameManager.instance.setting.gwenJointDump;
        }

        var rig = GetComponent<Rigidbody2D>();
        rig.mass = GameManager.instance.setting.gwenMass;
        rig.drag = GameManager.instance.setting.gwenLinearDrag;
        rig.angularDrag = GameManager.instance.setting.gwenAngularDrag;
    }

    void FixedUpdate()
    {
        if (joint2D)
        {
            var angle = Vector2.Angle(joint2D.connectedBody.transform.up, transform.up);
            var dis = Vector2.Distance(joint2D.connectedBody.transform.position, transform.position);

            if (Mathf.Abs(angle) > GameManager.instance.setting.breakAngle || dis > GameManager.instance.setting.breakDis)
            {
                GwenManager.instance.GwenFuckingDead();
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ground"))
        {
            GwenManager.instance.GwenFuckingDead();
        }
    }
}
