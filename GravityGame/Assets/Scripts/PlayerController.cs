using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Transform playerTransform;
    Animator anim;
    [SerializeField] float speed; // 250
    [SerializeField] float jumpForce; // 300
    [SerializeField] bool isAttacking = false;
    [SerializeField] float attackDuration;
    [SerializeField] float attackTimer;
    
    [SerializeField] UnityEngine.Vector3 boxSize;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int flipCount;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        Move();
        if(Input.GetButtonDown("Jump")){
            Flip();
        }
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }

    }

    private void Move(){
        
        float horiz = Input.GetAxisRaw("Horizontal");
        if(horiz == -1 && playerTransform.localScale.x > 0){
            playerTransform.localScale = new UnityEngine.Vector2(-playerTransform.localScale.x, playerTransform.localScale.y);
            anim.SetFloat("Speed", Mathf.Abs(horiz));
        }
        if(horiz == 1 && playerTransform.localScale.x < 0){
            playerTransform.localScale = new UnityEngine.Vector2(-playerTransform.localScale.x, playerTransform.localScale.y);
            anim.SetFloat("Speed", Mathf.Abs(horiz));
        }
        if(horiz == 0){
            anim.SetFloat("Speed", 0);
        }
        rb.velocity = new UnityEngine.Vector2(horiz*speed*Time.deltaTime, rb.velocity.y);

    }

    private void Attack(){
        anim.SetBool("Attack", true);
    }

    public void OnDoneAttacking(){
        anim.SetBool("Attack", false);
    }

    //private void Jump(){
    //    rb.velocity = new Vector2(rb.velocity.x, jumpForce*Time.deltaTime);
    //}

    private void Flip(){
        
        playerTransform.localScale = new UnityEngine.Vector2(playerTransform.localScale.x, -playerTransform.localScale.y);
        flipCount += 1;
        rb.gravityScale = -rb.gravityScale;

    }

//     public bool isGrounded(){
//         if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up,maxDistance,layerMask)){
//             return true;
//         }
//         else{
//             return false;
//         }
//     }



//     void OnDrawGizmos(){
//         Gizmos.color = Color.red;
//         Gizmos.DrawCube(transform.position-transform.up*maxDistance,boxSize);
//     }
}
