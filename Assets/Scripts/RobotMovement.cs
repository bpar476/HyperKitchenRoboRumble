using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    public float maxSpeed;
    public float acceleration;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb2d.velocity.x) < maxSpeed)
        {
            var input = Input.GetAxisRaw("Horizontal");
            if (input != 0)
            {
                rb2d.AddForce(new Vector2(Mathf.Sign(input) * acceleration, 0));
            }
        }
    }
}
