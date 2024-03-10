using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    public float Speed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Speed * Time.deltaTime;
        transform.Translate(distance, 0, 0, Space.Self);
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hip Hip");
            /*            GunController.HipHipHooray.text = "Hip Hip";*/
            GunController.hiphooraytext = "Hip Hip";
            GunController.changed = true;
            Destroy(gameObject);

        }

    }
}
