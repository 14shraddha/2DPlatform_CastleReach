using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //PRIVATE VARIABLES
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;


    // Use this for initialization
    void Start()
    {
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
}
