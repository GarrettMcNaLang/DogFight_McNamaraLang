using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject projPrefab;



    Vector2 PlayerFirePos;
    void Awake()
    {
        GM.instance.SpawnProjectile += CreateProjectile;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateProjectile(bool whoFired, Vector2 shooterTransform)
    {
        ProjectileScript ProjReference;
        GameObject prefabInstance;

        switch (whoFired) {

            case true:
                {
                    prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.up, Quaternion.identity);
                    
                  

                    break;
                }
            case false:
                {
                    prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.down, Quaternion.identity);
                   
                    break;
                }

               
        }

        ProjReference = prefabInstance.GetComponent<ProjectileScript>();


        ProjReference.OnInstantiate(whoFired);
    }
}
