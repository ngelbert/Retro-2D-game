using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D chara_rb;
    public float speed;
    Vector3 change;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        chara_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        // Debug.Log(change);
        updateState();
    }

    void UpdatePosition()
    {
        chara_rb.MovePosition((Vector2)(transform.position + change * speed * Time.deltaTime));
    }

    void setAnimMoveChara()
    {
        anim.SetFloat("Move_x", change.x);
        anim.SetFloat("Move_y", change.y);
    }

    void updateState()
    {
        if (change != Vector3.zero)
        {
            UpdatePosition();
            setAnimMoveChara();
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}

