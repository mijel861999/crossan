using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    


    public float speed = 3.1f;
    private float currentSpeed; 

    private bool walking = false;
    private bool attacking = false;

    public float attackTime;
    private float attackTimeCounter;

    public Vector2 lastMovement = Vector2.zero;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string atackingState = "Attacking";

    private Animator animator;
    private Rigidbody2D playerRigidbody;


    public string nextPlaceName;


    public static bool playerCreated;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();


        //si no se ha creado, lo que hará: 
        //1. Crearlo 
        //2. No destruir al cambiar de escena
        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Al principio siempre estarà quieto 
        walking = false;

        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidbody.velocity = Vector2.zero;
            animator.SetBool(atackingState, true);
        }


        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(atackingState, false);
            }
        }
        else
        {

           



            //Distancia  = Velocidad  * Tiempo

            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                //this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)*speed* Time.deltaTime,0,0));
                playerRigidbody.velocity = new Vector2(Input.GetAxis(horizontal) * currentSpeed * Time.deltaTime,
                     playerRigidbody.velocity.y);

                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
            }

            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                //this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x,
                    Input.GetAxis(vertical) * currentSpeed * Time.deltaTime);

                walking = true;
                lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
            }


            //Arreglando el bug de la velocidad en diagonales
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5 && Mathf.Abs(Input.GetAxisRaw(vertical)) >0.5)
            {
                //Esto porque está usando la diagonal, que es raiz de dos
                currentSpeed = speed / Mathf.Sqrt(2);
            }
            else
            {
                currentSpeed = speed;
            }
        }

        if (walking == false)
        {
            playerRigidbody.velocity = Vector2.zero;
        }



        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxis(vertical));

        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
