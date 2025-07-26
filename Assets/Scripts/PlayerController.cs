using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D PlayerRB;
    Animator PlayerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;
    bool facingRight = true;
    public bool isGrounded = false;
    
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    
    
    
    // Start gibi ama aktif olmasına gerek yok script sahnede var olduğu anda çalışır
    private void Awake()
    {
        
    }


    // Script aktif olunca çalışacak ilk kod || Sadece 1 kere çalışır
    void Start()
    {
        
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        
        
    }

    // frame odaklı çalışıyor yani 60 fps gibi || Görsel yenilemelelerde animasyon gibi galiba
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (PlayerRB.linearVelocity.x < 0 && facingRight)
        {
            //yüzünü çevir
            FlipFace();
        }
        else if (PlayerRB.linearVelocity.x > 0 && !facingRight)
        {
            //yüzünü çevir
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            //zıpla
            Jump();
        }
        
        
    }

    // zaman odaklı çalışıyor yani mesela saniyede 50 defa gibi || Fizik hesaplarında kullanılır yere düşme gibi galiba ya da hareket
    private void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        PlayerRB.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, PlayerRB.linearVelocity.y);
        PlayerAnimator.SetFloat("playerSpeed", Mathf.Abs(PlayerRB.linearVelocity.x));
    }


    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        PlayerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        PlayerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
