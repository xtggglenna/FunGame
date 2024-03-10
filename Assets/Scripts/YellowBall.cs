using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBall : MonoBehaviour
{
/*    private GunController gunController;*/

    private Vector3 startForce = new Vector3(6,0,6);
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);

    }

    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GunController.hiphooraytext = "Hooray";
            Debug.Log("Hooray");
            GunController.changed = true;
            GunController.points++;
            Debug.Log(GunController.points);

        }
    }

}
