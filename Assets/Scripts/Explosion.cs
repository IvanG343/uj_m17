using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Explosion : MonoBehaviour
{
    public Animator cannonballAnimator;
    public GameObject chest;
    public GameObject[] collectibleItemsArray;
    public GameObject pointEffector;

    private void Start()
    {
        cannonballAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cannonballAnimator.SetTrigger("Explode");
    }

    public void DisableChest()
    {
        Destroy(chest);
    }

    public void SpamItems()
    {
        foreach (GameObject item in collectibleItemsArray)
        {
            Instantiate(item, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void AddPointEffector()
    {
        GameObject clone = Instantiate(pointEffector, gameObject.transform.position, Quaternion.identity);
        Destroy(clone, 0.5f);
    }

    public void DeletePointEffector()
    {
        //Destroy(pointEffector);
    }

}
