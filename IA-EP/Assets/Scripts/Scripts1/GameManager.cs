using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	int N = 10;
	
	public static List<GameObject> agents = new List<GameObject>();


	void Start()
	{
		for (int i = 0; i < N; i++)
		{
			GameObject Sphere1 = Resources.Load<GameObject>("Sphere1");
			GameObject instance = Instantiate(Sphere1);

			instance.GetComponent<Sphere>().Sphere1 = GameObject.Find("Sphere2").transform;
			
			instance.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
			instance.name = "Sphere1" + i.ToString();
			
			agents.Add(instance);
		}

		agents.Add(GameObject.Find("Sphere2"));
	}
}

