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
    private float jumpForce;

    //PRIVATE VARIABLES
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;

    public float JumpForce
    {
        get
        {
            return JumpForce1;
        }

        set
        {
            JumpForce1 = value;
        }
    }

    public float JumpForce1
    {
        get
        {
            return jumpForce;
        }

        set
        {
            jumpForce = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        //PUBLIC VARIABLES
        this.velocityRange = new VelocityRange(300f, 400f);
        
        //PRIVATE VARIABLES
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;


    }

    // Update is called once per frame
    void Update()
    {
        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");
        if (this._move != 0)
        {
            if (this._move > 0)
            {
                this._facingRight = true;
                this._flip();
            }
            if (this._move <0)
            {
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
            //CALL JUMP SEQUENCE
            this._animator.SetInteger("AnimState", 2);
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

}
