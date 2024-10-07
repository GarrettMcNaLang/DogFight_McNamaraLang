using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject projPrefab;



    Vector2 PlayerFirePos;
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
        ProjectileScript ProjReference;
        GameObject prefabInstance;

       

        
        switch (whoFired) {

            case true:
                {
                    int FireTwice = 2;
                    do
                    {
                        Debug.Log("Creating player Projectile");
                        prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.up, Quaternion.identity);
                        Debug.Log(FireTwice);

                        FireTwice--;
                    }
                    while (FireTwice > 0);
                   
                    
                  

                    break;
                }
            case false:
                {
                    int FireTwice = 2;
                    do
                    {

                        Debug.Log("Creating enemy projectile");

                        prefabInstance = Instantiate(projPrefab, shooterTransform + Vector2.down, Quaternion.identity);
                        StartCoroutine(WaitTwoSecond());
                        Debug.Log(FireTwice);

                        FireTwice--;
                    }
                    while (FireTwice > 0);
                   
                   

                   
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
