using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject projPrefab;



    Vector2 PlayerFirePos;
    void Awake()
    {
        Debug.Log("Combat Manager Reporting for duty");
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
       // Debug.Log("accessing CreateProjectile");
        ProjectileScript ProjReference;
        GameObject prefabInstance;



        switch (whoFired)
        {

            case true:
                {
                    Debug.Log("Creating player Projectile");
                    prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.up, Quaternion.identity);

                    StartCoroutine(WaitTwoSecond());
                        //Debug.Log("Creating player Projectile");
                     //prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.up, Quaternion.identity);
                     
                    
                  




                    break;
                }
            case false:
                {
                    Debug.Log("Creating enemy projectile");
                    prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.down, Quaternion.identity);
                  
                   
                        Debug.Log("Creating enemy projectile");
                      //prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.down, Quaternion.identity);
                      
                       
                      


                    break;
                }


        }

        ProjReference = prefabInstance.GetComponent<ProjectileScript>();


        ProjReference.OnInstantiate(whoFired);
    }
    IEnumerator WaitTwoSecond()
    {
        yield return new WaitForSeconds(2);
    }
}


