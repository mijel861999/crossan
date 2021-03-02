using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    /*
    public float timeToRevivePlayer = 2; //Tiempo que tardará el player en renacer
    private float timeRevivalCounter;//El contador de la variable - timeToRevivePlayer

    private bool playerReviving;//Nos dice si el personaje esta reviviendo


    private GameObject thePlayer;//El game Object del personaje, que nos ayudará a descativarlo cunado haya collision
    */


    public int damage = 10;


    void Start()
    {
        
    }

    /*
    void Update()
    {
        if (playerReviving)//Si el personaje está reviviendo 
        {
            timeRevivalCounter -= Time.deltaTime; //El contador empezará a disminuir
            if(timeRevivalCounter < 0)//Cuando llegue a menos de 0
            {
                playerReviving = false; //Ya no estará reviviendo
                thePlayer.SetActive(true); //Activamos el game object
            }
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        { 
            //ESTO ES CUANDO SOLO TOCABA A UN ENEMIGO Y SE MORÍA ->
            //colision entre jugador y enemigo
            //collision.gameObject.SetActive(false);//Si chocan, desactivaremos el player
            //playerReviving = true; //pondremos en marcha el contador de revivir
            //timeRevivalCounter = timeToRevivePlayer;//Reinicia el contador
            //thePlayer = collision.gameObject; //inicializa el valor de - thePlayer

            collision.gameObject.GetComponent<HealthManager>().damageCharacter(damage);
        }
    }

}
