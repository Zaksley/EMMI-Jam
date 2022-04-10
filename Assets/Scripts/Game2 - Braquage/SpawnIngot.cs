using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngot : MonoBehaviour
{
    
    public GameObject[] spawnLocations; 
    public List<GameObject> Locations;
    [SerializeField] private GameObject prefabIngot;
    
    [SerializeField] private float spawnTime;

    void Start()
    {
        Locations = new List<GameObject>(); 

        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        
        for(int i=0; i<spawnLocations.Length; i++)
        {
            Locations.Add(spawnLocations[i]); 
        }

        InvokeRepeating("SelectSpawn", spawnTime, spawnTime);

    }

    private void SelectSpawn()
    {
        if (Locations.Count > 0)
        {
            int spawnIndex = Random.Range(0, Locations.Count);

            for(int i=0; i<spawnLocations.Length; i++)
            {
                if (ReferenceEquals(Locations[spawnIndex], spawnLocations[i]))
                {
                    CreateIngot(i);
                    return;
                }
            }
        }
        
        return;
    }

    private void CreateIngot(int index)
    {
        Vector3 position = spawnLocations[index].transform.position;
        GameObject ingot = Instantiate(prefabIngot, position, Quaternion.identity);
        ingot.GetComponent<IngotCollision>().index = index;

        // Remove location from list
        for(int i=0; i<Locations.Count; i++)
        {
             if (ReferenceEquals(Locations[i], spawnLocations[index]))
            {
                Locations.RemoveAt(i);
                return;
            }
        }
    }

    public void addLocation(int index) 
    {
        Locations.Add(spawnLocations[index]);
    }
}
