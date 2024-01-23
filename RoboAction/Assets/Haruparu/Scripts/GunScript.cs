using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject firingPoint;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 bulletPosition = firingPoint.transform.position;
            GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
            Vector3 direction = newBall.transform.forward;
            newBall.GetComponent<Rigidbody>().AddForce(direction * -speed, ForceMode.Impulse);
            Destroy(newBall, 0.8f);
        }
    }
}
