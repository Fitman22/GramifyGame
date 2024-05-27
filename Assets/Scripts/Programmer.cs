using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programmer : MonoBehaviour
{
    [SerializeField] float speed;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Move(Vector2 position)
    {
        rb.velocity = position*speed;
        if (rb.velocity.magnitude != 0)
        {
            if(rb.velocity.x>0)sprite.flipX = true;
            else if(rb.velocity.x<0) sprite.flipX = false;
            anim.SetFloat("MoveX", position.x);
            anim.SetFloat("MoveY", position.y);
            anim.SetBool("OnMove", true);
        }
        else { anim.SetBool("OnMove", false); }
     
    }
    private void Update()
    {
        Move(ControlsManager.getControls().Move.ReadValue<Vector2>());
    }
}
