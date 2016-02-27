using UnityEngine;
using System.Collections;


//VELOCITY RANGE UTILITY RANGE CLASS ***********************************
[System.Serializable]
public class VelocityRange
{
    //PUBLIC VARIABLES
    public float minimum;
    public float maximum;

    //CONSTRUCTOR
    public VelocityRange(float minimum,float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
   
}

public class HeroController : MonoBehaviour {

    //PUBLIC VARIABLES
    public VelocityRange velocityRange;
    public float moveFoce;
    public float jumpForce;
    public Transform groundCheck;
    public Transform camera;


    //PRIVATE VARIABLES
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2d;
    private bool _isGrounded;

    
    // Use this for initialization
    void Start()
    {
        //PUBLIC VARIABLES
        this.velocityRange = new VelocityRange(200f, 210f);
        
        //PRIVATE VARIABLES
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;

        // PLACE HERO ON CORRECT POSITION
        this._spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = new Vector3(this._transform.position.x, this._transform.position.y,-10f);
        this.camera.position = currentPosition;


        this._isGrounded = Physics2D.Linecast(
                                        this._transform.position,
                                        this.groundCheck.position,
                                        1<<LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this._transform.position,this.groundCheck.position);

        
        float forceX = 0f;
        float forceY = 0f;

        //GET ABSOLUTE VALUES OF VELOCITY FOR GAMEOBJECT
        float absVelX = Mathf.Abs(this._rigidBody2d.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2d.velocity.y);

       
        //ENSURE THE PLAYER IS ON GROUND BEFOR ANTY MOVEMENT CHECK
        if (this._isGrounded)
        {
            //GET A NUMBER BETWEEN -1 TO 1 HORIZONTAL AND VERTICAL AXIS
            this._move = Input.GetAxis("Horizontal");
            this._jump = Input.GetAxis("Vertical");

            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    //  MOVEMENT FORCE
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = this.moveFoce;
                    }
                    this._facingRight = true;
                    this._flip();
                }
                if (this._move < 0)
                {
                    //  MOVEMENT FORCE
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = -this.moveFoce;

                    }
                    this._facingRight = false;
                    this._flip();
                }

                //CALL WALK SEQUENCE
                this._animator.SetInteger("AnimState", 1);
            }
            else
            {
                //SET IDLE STATE
                this._animator.SetInteger("AnimState", 0);
            }

            if (this._jump > 0)
            {
                //  JUMP FORCE 
                if (absVelY < this.velocityRange.maximum)
                {
                    forceY = this.jumpForce;
                }
            }
        }
        else
        {
            //CALL JUMP SEQUENCE
            this._animator.SetInteger("AnimState", 2);
        }

        //APPLY FORCES TO HERO
        this._rigidBody2d.AddForce(new Vector2(forceX, forceY));
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            this._spawn();
        }
    }

    //PRVATE METHODS
    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }

    private void _spawn()
    {
        this._transform.position = new Vector3(-840f, -150f, 0);
    }
}
