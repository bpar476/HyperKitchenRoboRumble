using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaWeapon : MonoBehaviour
{

    public float launchForce;
    public Transform spatula;
    private bool notFlipping = true;

    private List<GameObject> thingsOnMe;

    private void Start()
    {
        thingsOnMe = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notFlipping && Input.GetAxisRaw("Fire1") != 0)
        {
            StartCoroutine(FlipSpatula());
        }
    }

    IEnumerator FlipSpatula()
    {
        notFlipping = false;
        for (var i = 0; i < 45; i++)
        {
            transform.eulerAngles = new Vector3(0, 0, i);
            yield return null;
        }

        thingsOnMe.ForEach(gobj =>
        {
            var rb = gobj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("launching object");
                rb.AddForce(spatula.transform.up.normalized * launchForce, ForceMode2D.Impulse);
            }
        });

        yield return new WaitForSeconds(1);

        for (var i = 45; i > 0; i--)
        {
            transform.eulerAngles = new Vector3(0, 0, i);
            yield return null;
        }

        notFlipping = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        thingsOnMe.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        thingsOnMe.Remove(other.gameObject);
    }
}
