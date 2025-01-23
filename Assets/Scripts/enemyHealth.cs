using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 100;
    public int dmgTaken = 50;
    public LogicScript logicScript;

    private void Start()
    {
       logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void takeDamage()
    {
        health -= dmgTaken;
        if (health <= 0)
        {
            Destroy(gameObject);
            logicScript.addScore();
        }
    }
}
