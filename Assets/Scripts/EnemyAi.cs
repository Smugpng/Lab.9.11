using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAi : MonoBehaviour
{


    private GameObject playerShip;
    private float rotSpeed;
    private float maxDistance;
    private int rng;
    private GameObject[] pals;
    // Start is called before the first frame update
    void Start()
    {
        pals = GameObject.FindGameObjectsWithTag("Pals");
        playerShip = GameObject.FindWithTag("Player");
        maxDistance = Random.Range(2, 7);
        rotSpeed = Random.Range(10, 50) * maxDistance;
        rng = Random.Range(0,5);
    }

    // Update is called once per frame
    void Update()
    {
        CalcDistance();
        RotateThis();
        Look();
    }
    private void CalcDistance()
    {
        Vector3 point1 = this.transform.position;
        Vector3 point2 = playerShip.transform.position;
        var distance = (point1 - point2).magnitude;
        Debug.Log(distance);
        if (distance < maxDistance) MoveAway();
        if (distance > maxDistance) MoveTowards();
    }

    private void MoveAway()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, -10 *Time.deltaTime);
    }
    private void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, 2 * Time.deltaTime);
    }
    private void RotateThis()
    {
        if (rng % 2 == 0) transform.RotateAround(playerShip.transform.position, Vector3.forward, rotSpeed * Time.deltaTime);
        else transform.RotateAround(playerShip.transform.position, -Vector3.forward, rotSpeed * Time.deltaTime);
    }
    private void Look()
    {
        
        Vector3 look = transform.InverseTransformPoint(playerShip.transform.position);
        float angle = Mathf.Atan2(look.y, look.x)* Mathf.Rad2Deg-90;
        transform.Rotate(0,0,angle);
    }
}
