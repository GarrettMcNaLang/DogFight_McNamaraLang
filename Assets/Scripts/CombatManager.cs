using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject PlayerProjPrefab;
    public GameObject EnemyProjPrefab;


    //Vector2 PlayerFirePos;
    void Awake()
    {
       
    }

    void OnEnable()
    {
        
        //GM.instance.SpawnProjectile += CreateProjectile;
        Debug.Log("Combat manager reporting for duty");
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
        Debug.Log("accessing CreateProjectile");
      
        GameObject prefabInstance;




        switch (whoFired)
        {

            case true:
                {
                   
                        Debug.Log("Creating player Projectile");
                        prefabInstance = Instantiate(PlayerProjPrefab, shooterTransform + Vector2.up, Quaternion.identity);
                        

                    




                    break;
                }
            case false:
                {
                    
                    

                        Debug.Log("Creating enemy projectile");

                        prefabInstance = Instantiate(EnemyProjPrefab, shooterTransform + Vector2.down, Quaternion.identity);

                     

                        
                    
                  




                    break;
                }


        }

        


    }
    }


