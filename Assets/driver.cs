using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    [SerializeField] float steerSpeed=300f;
    [SerializeField] float moveSpeed=10f;
    [SerializeField] float boostSpeed=15f;
    [SerializeField] float slowSpeed=5f;
    bool speedup;
    bool slowdown;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SpeedUp" && !speedup)
        {
            moveSpeed = boostSpeed;
            speedup = true;
            slowdown = false;
        }
        if(other.tag == "SlowDown" && !slowdown)
        {
            moveSpeed = slowSpeed;
            slowdown = true;
            speedup = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed* Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical")*moveSpeed* Time.deltaTime;
         transform.Rotate(0,0,-steerAmount) ;
         transform.Translate(0,speedAmount,0);
         
    }
}
