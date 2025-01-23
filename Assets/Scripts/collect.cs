using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public LogicScript logicScript;
    private bool collected;
    private void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        collected = false;
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        Debug.Log(gameObject.name);
        Debug.Log(hitObject.name);
        if (hitObject.gameObject.layer == 3 && collected == false)
        {
            collected = true;
            Debug.Log("Destroyed");
            logicScript.addScore();
            Destroy(gameObject);
        }
    }
}
