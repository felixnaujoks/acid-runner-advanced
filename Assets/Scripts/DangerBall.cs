using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBall : MonoBehaviour
{
    //rivate bool leftCheck;
    [SerializeField] private float _movingSpeed = 4f;
    
    // defines the starting direction
    private Vector3 direction = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {
        //leftCheck = true;
    }

    // Update is called once per frame
    void Update()
    {   
        // starts the movement in the given direction
        transform.Translate(direction * _movingSpeed * Time.deltaTime);
        // spins the dangerball(spikeball) around itself
        transform.Rotate (0,0,150*Time.deltaTime);
        
        // moves to one direction until a certain point
        if (transform.position.z <= -12)
        {
            direction = Vector3.forward;
        }
        // moves in the opposite direction
        else if (transform.position.z >= 12)
        {
            direction = Vector3.back;
        }
    }
    // calls the damage function to reduce live points
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage();
        }
    }
}