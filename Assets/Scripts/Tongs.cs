using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongs : MonoBehaviour
{
    private bool isCoroutineExecuting = false;

    private Collider2D currentCollision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentCollision != null)
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
