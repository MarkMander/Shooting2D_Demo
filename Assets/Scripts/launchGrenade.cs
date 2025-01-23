using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class launchGrenade : MonoBehaviour
{
    public GameObject grenade;
    public Transform launchPt;
    public float grenadeSpd;
    private float grenadeAngle;

    void Start()
    {
        grenadeAngle = 45; //fill this in with angle based on grenade fire point
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            spwnGrenade();
        }
    }

    private void spwnGrenade()
    {
        GameObject liveGrenade = Instantiate(grenade, launchPt.position, launchPt.rotation);

        Rigidbody2D grenadeRigid = liveGrenade.GetComponent<Rigidbody2D>();
        
        grenadeRigid.velocity = new Vector3 (launchPt.right.x*grenadeSpd*Mathf.Cos(grenadeAngle), grenadeSpd*Mathf.Sin(grenadeAngle), 0);

    }

}
