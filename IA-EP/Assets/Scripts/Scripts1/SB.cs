using UnityEngine;
using System.Collections.Generic;

namespace AI
{
	public class SB
	{
		public Vector3 seek(BaseAgent agent, Vector3 targetPosition, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;

			if (difference.magnitude < range)
			{
				desired = difference.normalized * agent.maxForce;
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		public Vector3 arrive(BaseAgent agent, Vector3 targetPosition, float arriveRange, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;
			float distance = difference.magnitude;
			
			if (distance < range)
			{				
				if (distance > arriveRange)
				{
					desired = difference.normalized * agent.maxForce;
				}
				else
				{
					desired = difference * agent.maxForce;
				}
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		public Vector3 flee(BaseAgent agent, Vector3 targetPosition, float range = 999999)
		{
			Vector3 desired;
			Vector3 difference = targetPosition - agent.transform.position;

			if (difference.magnitude < range)
			{
				desired = -difference.normalized * agent.maxForce;
			}
			else
			{
				desired = Vector3.zero;
			}

			return desired;
		}

		Vector3 randomTargetPosition = Vector3.zero;
		float timer = 0;

		public Vector3 random(BaseAgent agent, Vector3 position, float radius, float frequency)
		{
			timer += Time.deltaTime;

			if (timer >= frequency)
			{
				timer = 0;
				randomTargetPosition = (Vector2)position + Random.insideUnitCircle * Random.Range(0, radius);
			}

			return seek(agent, randomTargetPosition);
		}

		public Vector3 separate(BaseAgent agent, List<Transform> neighbors, float range)
		{
			Vector3 desired = Vector3.zero;

			foreach (var neighbor in neighbors)
			{
				Vector3 difference = agent.transform.position - neighbor.position;
				if (difference.magnitude > range) continue;

				Vector3 desiredAux = difference.normalized * agent.maxForce;
				desired += desiredAux;
			}

			return desired;
		}		

		public Vector3 wander(BaseAgent agent, float wanderDistance, float wanderRadius)
		{
			
			float wanderAngle = Random.Range(-180, 180);
			Vector3 center = agent.transform.position + agent.velocity.normalized * wanderDistance;
			Vector3 wRef = agent.velocity.normalized * wanderRadius;
			Vector3 wRefRotated = Quaternion.Euler(0, 0 , wanderAngle) * wRef;
			Vector3 d = center + wRefRotated - agent.transform.position;

			Vector3 desired = (d - agent.transform.position).normalized * agent.maxForce;

			Debug.DrawLine(agent.transform.position, d + agent.transform.position);
			
			return desired;
		}		
	}	
}
