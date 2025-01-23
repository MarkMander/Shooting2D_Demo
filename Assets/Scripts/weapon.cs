using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePt;
    private bool queueFire;
    public LineRenderer fireRay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireWeapon());
        }
    }

    IEnumerator FireWeapon()
    {
        //LayerMask layerMask = LayerMask.GetMask("enemyAndObjects");
        RaycastHit2D gunHit = Physics2D.Raycast(firePt.position, firePt.right, Mathf.Infinity);

        Vector3[] positions = new Vector3[2];
        positions[0] = firePt.position;
        if (gunHit)
        {
            enemyHealth hitEnemy = gunHit.transform.GetComponent<enemyHealth>();
            if (hitEnemy != null)
            {
                hitEnemy.takeDamage();
            }
            Debug.Log(gunHit.transform.name);
            Debug.DrawLine(firePt.transform.position, gunHit.transform.position, Color.red, 2f, false);

            positions[1] = gunHit.point;
            //positions[1] = new Vector3(gunHit.transform.position.x,firePt.position.y,gunHit.transform.position.z); //set the y to the firepoint to make ray level with gun

        }
        else
        {
            Debug.Log("no hit");
            positions[1] = positions[0] + firePt.right * 10;

        }

        fireRay.positionCount = positions.Length;
        fireRay.SetPositions(positions);
        fireRay.enabled = true;
        
        yield return new WaitForSeconds(0.04f);

        fireRay.enabled = false;

        /*if (Physics.Raycast(firePt.position, firePt.TransformDirection(Vector3.forward), out gunHit,Mathf.Infinity,layerMask))
        {
            Debug.DrawLine(firePt.position, firePt.TransformDirection(Vector3.forward) * gunHit.distance, Color.red);
            Debug.Log("hit " + gunHit);
        } 
        else
        {
            Debug.Log("no Hit");
            Debug.DrawLine(firePt.position, firePt.TransformDirection(Vector3.forward) * 1000, Color.blue);
        }*/


    }
}
