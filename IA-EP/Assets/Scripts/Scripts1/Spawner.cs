using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject Sphere;
    
    public float spawnTimeA = 2f;

    void Start()
    {
     InvokeRepeating ("Spawner A",spawnTimeA, spawnTimeA);     
    }    

    void SpawnA()
    {
     var newEnemie = GameObject.Instantiate(Sphere,transform.position,Quaternion.identity);
    }

}
