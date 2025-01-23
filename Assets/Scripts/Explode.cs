using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public LogicScript logicScript;
    private void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        Debug.Log(hitObject.name);
        Debug.Log(hitObject.gameObject.layer);
        if (hitObject.gameObject.layer == 8)
        {
            Destroy(hitObject.gameObject);
            logicScript.addScore();
            Debug.Log("Destroyed");
        }
        Destroy(gameObject);
        
    }
}
