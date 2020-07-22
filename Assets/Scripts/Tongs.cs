using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongs : AbstractWeapon
{
    private bool isCoroutineExecuting = false;

    private Collider2D currentCollision;

    public override void Use()
    {
        if (currentCollision != null)
        {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.anchor = currentCollision.offset;
            joint.connectedBody = currentCollision.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            joint.breakForce = 1000;
            joint.enableCollision = false;
            StartCoroutine(ExecuteAfterTime(3.0f, () => { Destroy(joint); }));
        }
    }

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentCollision = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentCollision = null;
    }
}
