using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
	public class BaseAgent : MonoBehaviour
	{
		public Vector3 velocity;
		public Vector3 desired;
		public Vector3 steer;

		public bool calculateAfterUpdate = true;

		public float maxForce = 1;
		public float maxSteer = 1;

		SB sb = new SB();

		public void addSeek(Vector3 targetPosition, float range = 999999)
		{
			Vector3 seek = sb.seek(this, targetPosition, range);
			desired += seek;
		}

		public void addArrive(Vector3 targetPosition, float arriveRange, float range = 999999)
		{
			Vector3 arrive = sb.arrive(this, targetPosition, range);
			desired += arrive;
		}

		public void addFlee(Vector3 targetPosition, float range = 999999)
		{
			Vector3 flee = sb.flee(this, targetPosition, range);
			desired += flee;
		}

		public void addSeparate(List<Transform> neighbors, float range = 999999)
		{
			Vector3 separate = sb.separate(this, neighbors, range);
			desired += separate;
		}

		public void addWander(float wanderDistance, float wanderRadius)
		{
			Vector3 wander = sb.wander(this, wanderDistance, wanderRadius);
			desired += wander;
		}

		public void calculate()
		{
			steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
			velocity += steer;
			desired = Vector3.zero;
			transform.position += velocity * Time.deltaTime;
		}

		public void LateUpdate()
		{
			if (calculateAfterUpdate) calculate();
		}
	}
}
