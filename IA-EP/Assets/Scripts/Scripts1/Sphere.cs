using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class Sphere : BaseAgent
{
    public Transform Sphere1;
   // public Transform Sphere2;
    int currentIndex = -1;
    Vector3 targetPosition;

    void Start()
    {
        maxForce = 5;
        maxSteer = 0.3f;

        Global.path.Add(GameObject.Find("Point 1").transform);
        Global.path.Add(GameObject.Find("Point 2").transform);
        Global.path.Add(GameObject.Find("Point 3").transform);
        Global.path.Add(GameObject.Find("Point 4").transform);

        SetNextTarget();
    }

    void Update()
    {
        addSeek(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 1)
        {
            SetNextTarget();
        }

        /* velocity += SB.Arrive(this, Sphere1, 3);
		velocity += SB.Flee(this, Sphere2, 1);
		velocity += SB.Separate(this, GameManager.agents, 2f);
		transform.position += velocity * Time.deltaTime;*/
    }

    void SetNextTarget()
    {
        currentIndex++; if (currentIndex == Global.path.Count) currentIndex = 0;
        targetPosition = Global.path[currentIndex].position;
    }
}
