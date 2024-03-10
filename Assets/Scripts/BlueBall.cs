using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    public float Speed = 50;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Speed * Time.deltaTime;
        transform.Translate(0, 0, distance, Space.Self);
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
            GunController.hiphooraytext = "Hip Hip";
            GunController.changed = true;
            Destroy(gameObject);

        }
    }
}
