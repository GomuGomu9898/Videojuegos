using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    
    public GameObject capsule;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            int posibility = Random.Range(1,6);
            if(posibility == 1)
            {
                Instantiate(capsule, this.transform.position,capsule.transform.rotation);
            }
            GameManager.instance.BrickDestroy();
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        
        GetComponent<Renderer>().material.color = randomColor;
    }
}