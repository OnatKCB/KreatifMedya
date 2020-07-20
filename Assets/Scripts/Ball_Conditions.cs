using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Conditions : MonoBehaviour
{
    Puzzle_Manager pm;

    float time = 20f;

    void Start()
    {
        pm = (Puzzle_Manager)FindObjectOfType(typeof(Puzzle_Manager));
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0) 
        {
            time = 0;
        }
        Debug.Log(time);
        if (time == 0) 
        {
            pm.GetComponent<Puzzle_Manager>().Failure();
        }
    }

    public void resetTime() 
    {
        time = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pm = (Puzzle_Manager)FindObjectOfType(typeof(Puzzle_Manager));
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target_Zone")
        {
            pm.GetComponent<Puzzle_Manager>().Succeed();
            pm.GetComponent<Puzzle_Manager>().nextPuzzle();
        }
        if (other.gameObject.tag == "Failure_Zone" || other.gameObject.tag == "Failure_Object")
        {
            pm.GetComponent<Puzzle_Manager>().Failure();
            //pm.GetComponent<Puzzle_Manager>().newPuzzle();
        }
    }
}
