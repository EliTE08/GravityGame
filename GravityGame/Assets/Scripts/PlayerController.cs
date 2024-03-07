using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed; // 250
    [SerializeField] float jumpForce; // 300
    
    [SerializeField] Vector3 boxSize;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        Debug.Log(vert);
        Move();
        if(vert > 0 && isGrounded()){
            Jump();
        }
        if(Input.GetButtonDown("Jump")){
            Flip();
        }
    }

    private void Move(){
        
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz*speed*Time.deltaTime, rb.velocity.y);

    }

    private void Jump(){

        rb.velocity = new Vector2(rb.velocity.x, jumpForce*Time.deltaTime);

    }

    private void Flip(){
        
        rb.gravityScale = -rb.gravityScale;

    }

    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up,maxDistance,layerMask)){
            return true;
        }
        else{
            return false;
        }
    }



    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance,boxSize);
    }
}
