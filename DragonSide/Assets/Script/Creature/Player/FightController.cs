using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : Creture
{[Header("Components")]
    [SerializeField] private Collision coll;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BetterJumping _bt;
    [SerializeField] private BoxCollider2D Damage;
    
    [Space]
    [Header("Stats")]
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _horizontalDirection;
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _GroundlinearDrag;
    [SerializeField] private float _AirlinearDrag;
    [SerializeField] private float _dashDist;
    [SerializeField] private float _strikeDist;
    private Vector2 mousePosition, mouseDirection;
    [Space]
    [Header("Booleans")]
   
    [SerializeField] private bool wallJumped;
    [SerializeField] private bool wallSlide;
    [SerializeField] private bool HasDashToken = true;
    private bool active = true;
    private bool _changingDirection;
    [Space]

   
    private bool hasDashed;
    public int side = 1;

  
    private void Start()
    {
        coll = GetComponent<Collision>();
        _rb = GetComponent<Rigidbody2D>();
        _bt = GetComponent<BetterJumping>();
    }

    private void Update()
    {
        _horizontalDirection = GetInput().x;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePosition - _rb.position).normalized; Debug.Log(mouseDirection);

        if (Input.GetButtonDown("Jump") && coll.onGround && !coll.onWall) Jump();
        if (Input.GetButtonDown("Dash")/*& HasDashToken*/) StartCoroutine(Dash(mouseDirection));
        
        Debug.DrawRay(transform.position, mouseDirection, Color.green);
    }
    private void FixedUpdate()
    {
        MoveCharacter();
      

        if (!coll.onGround) { ApplyAirLinearDrag(); } else ApplyGroundLinearDrag();
        GetChangingDirection();
        _bt.FallMultiplier(_rb, active);
       

    }
    private IEnumerator Dash(Vector2 dir)
    {
        Debug.Log("DASH");
        _rb.velocity = Vector2.zero;
        active = false;
        _GroundlinearDrag = 1;
        _rb.gravityScale = 0;
        _rb.AddForce(dir * _dashDist, ForceMode2D.Impulse);
        Damage.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        Damage.gameObject.SetActive(false);
        active = true;
        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;
        _GroundlinearDrag = 4;
    }
   
    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Jump()
    {

        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
       
        //if (!coll.onWall)
        //{
        //    _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        //    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        //}
        //else
        //{ _rb.AddForce(Vector2.up * (_jumpForce*0.4f), ForceMode2D.Impulse); }
        
    }
    private void MoveCharacter()
    {
        _rb.AddForce(new Vector2(_horizontalDirection, 0.0f) * _movementAcceleration);
        if (Mathf.Abs(_rb.velocity.x) > _maxSpeed)
        { _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _maxSpeed, _rb.velocity.y); }
    }
    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(_horizontalDirection) < 0.4 || _changingDirection)
        {
            _rb.drag = _GroundlinearDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    
    }
    private void ApplyAirLinearDrag()
    {
        _rb.drag = _AirlinearDrag;
    }
        private bool GetChangingDirection()
    {
        if ((_rb.velocity.x > 0f && _horizontalDirection < 0) || (_rb.velocity.x < 0f && _horizontalDirection > 0))
            _changingDirection = true;
        else
            _changingDirection = false;

        return _changingDirection;
    }
    //private void FixedUpdate()
    //{
    //    //Sharp slow down when moving up and slow landing
    //    if (GC.isGrounded() == false && _rb.velocity.y > 0)
    //    {
    //        _rb.velocity = _rb.velocity * 0.9f;
    //    }
    //    //Moving from side to side on A and D when on ground
    //    if ((GetDirection().x != 0 || GetDirection().y != 0) && GC.isGrounded())
    //        _rb.velocity = new Vector2(speed * GetDirection().x, _rb.velocity.y);
    //    //On shift if you are on ground dash to mouse position
   
}
