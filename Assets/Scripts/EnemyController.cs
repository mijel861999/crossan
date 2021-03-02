using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemySpeed = 1;
    private Rigidbody2D enemyRigidbody;
    private Animator enemyAnimator;
    
    private bool isMoving;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    //Tiempo que debe pasar de un movimiento a otro
    public float timeBetweenSteps = 2f;
    //Cuanto tiempo ha pasado desde el último movimiento 
    private float timeBetweenStepCounter;



    //el tiempo que tarda en dar un paso de celda a otra
    public float timeToMakeStep = 1.5f;
    //tiempo que ha pasado desde que empezó el movimiento
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;



    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        //Para que cuando dupliquemos al enemigo tenga una aleatoridad para cada uno, multiplicaremos por un numero random
        //a cada contador
        timeBetweenStepCounter = timeBetweenSteps*Random.Range(0.5f, 1.5f);
        timeToMakeStepCounter = timeToMakeStep * Random.Range(0.5f, 1.5f);

    }

    
    void Update()
    {
        if (isMoving)
        {
            //Tiempo que tarda en hacer un paso
            timeToMakeStepCounter -= Time.deltaTime;//descuenta el tiempo del úlitmo renderizado
            enemyRigidbody.velocity = directionToMakeStep;//movemos el enemigo en esta dirección
            if (timeToMakeStepCounter < 0)//Se acaba el tiempo del movimiento
            {
                isMoving = false;
                //Tiempo que tarda en volver a hacer un paso
                timeBetweenStepCounter = timeBetweenSteps;//reinicia el contador
                enemyRigidbody.velocity = Vector2.zero;//para el movimiento
            }
        }
        else//si no se está moviendo
        {
            
            timeBetweenStepCounter -= Time.deltaTime; //Resta tiempo del contador
            if (timeBetweenStepCounter < 0)//Si se acaba el tiempo para esperar el siguiente movimiento 
            {
                isMoving = true; //nos podemos empezar a movernos
                timeToMakeStepCounter = timeToMakeStep; //reiniamos el contador
                //ponemos una dirección aleatoria
                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed;
            }
        }

        //cambiamos las animaciones
        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
    }
}
