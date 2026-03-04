using UnityEngine;

public class Ball : MonoBehaviour
{

    public float launchSpeed = 8f;
    
    public bool launched = false;

    private Rigidbody rb;

    [Header("Referencia al Pad")]
    public Transform padTransform;
    private Vector3 offsetFromPad = new Vector3(0f, 0.65f, 0f);
    void Awake()
    {
        // Obtenemos la referencia al Rigidbody antes de iniciar
        rb = GetComponent<Rigidbody>();
        padTransform = GameObject.Find("Pad").transform;
    }

/*    void Start()
    {
        Launch();
    }
*/
    public void Launch()
    {
        //lanz en diagon
        float angle = Random.Range(10f,170f);
        float radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(radians),Mathf.Sin(radians),0f);
        rb.velocity = direction.normalized * launchSpeed;
        launched = true;
    }

    void FollowPad()
    {
        transform.position = padTransform.position + offsetFromPad;
    }

    void ResetBall()
    {
        launched = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        FollowPad();
    }

    public void MultiplySpeed(int multi)
    {
        launchSpeed = launchSpeed * multi;
    }
        public void DivideSpeed(int div)
    {
        launchSpeed = launchSpeed / div;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            GameManager.instance.LoseLifes();
            ResetBall();
        }
    }

    void Update()
    {
        if (!launched)
        {
            FollowPad();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }
}