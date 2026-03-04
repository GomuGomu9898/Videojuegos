using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Capsule : MonoBehaviour
{
    public float speed = 5f;
    public Transform currentBall;
    public GameObject prefabBall;
    public int type = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBall = GameObject.FindGameObjectWithTag("Ball").transform;
        type = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            switch (type)
            {
                case 0:
                    //Debug.Log("PowerUp1");
                    StartCoroutine(MultiBall());
                    break;
                case 1:
                    //Debug.Log("PowerUp1");
                    StartCoroutine(ExtraSpeed());
                    break;
            }
        }
    }

    IEnumerator MultiBall()
    {
        var newBall1 = Instantiate(prefabBall, currentBall.position, Quaternion.identity);
        newBall1.GetComponent<Ball>().Launch();
        var newBall2 = Instantiate(prefabBall, currentBall.position, Quaternion.identity);
        newBall2.GetComponent<Ball>().Launch();

        yield return new WaitForSeconds(15f);

        Destroy( newBall1.gameObject);
        Destroy( newBall2.gameObject);
        
    }

    IEnumerator ExtraSpeed()
    {
        currentBall.gameObject.GetComponent<Ball>().MultiplySpeed(2);
        yield return new WaitForSeconds(3f);
        currentBall.gameObject.GetComponent<Ball>().DivideSpeed(2);
        
    }
}
