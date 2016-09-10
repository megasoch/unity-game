using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public int enemyAction; //0 - patrol, 1 - purchase, 2 - atack

    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float rotateSpeed = 10.0f;

    public GameObject cube1;
    public GameObject cube2;

    private bool alive;
    private float hp;

    public Animator animator;

    private RaycastHit enemyRay;
    private RaycastHit enemyEyes;

    public float halfViewAngle = 90.0f;

    private NavMeshAgent navMeshAgent;

    public PlayerScript player;


    // Use this for initialization
    void Start()
    {
        hp = 3.0f;
        alive = true;
        enemyAction = 0;
        navMeshAgent = (NavMeshAgent)this.GetComponent("NavMeshAgent");
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out enemyRay, 1000.0f);
        Debug.DrawLine(transform.position, enemyRay.collider.transform.position, Color.blue);

        if(alive == true)
        {
            if (enemyAction == 0)
            {
                patrolAction();
                if (enemyRay.collider.tag == "enemypoint")
                {
                    transform.position += transform.forward * walkSpeed * Time.deltaTime;
                }
            }
            if (enemyAction == 1)
            {
                purchaseAction();
            }
            if (enemyAction == 2)
            {
                attackAtcion();
            }
            detectPlayer();
        }
        else
        {
            navMeshAgent.enabled = false;
            animator.SetBool("alive", false);
            GetComponent<CapsuleCollider>().enabled = false;
        }
        
    }

    private void patrolAction()
    {
        if (Vector3.Distance(transform.position, cube1.transform.position) < 2f)
        {
            var relativePos = cube2.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(relativePos);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, cube2.transform.position) < 2f)
        {
            var relativePos = cube1.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(relativePos);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
        if (detectPlayer())
        {
            enemyAction = 1;
            animator.SetBool("run", true);
            animator.SetBool("walk", false);
        }
    }

    private void purchaseAction()
    {
        eyesOnPlayer();
        navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.5f)
        {
            enemyAction = 2;
            animator.SetBool("attack", true);
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            navMeshAgent.speed = 0;
        }
    }


    private void attackAtcion()
    {
        eyesOnPlayer();
        player.decreaseHp(Time.deltaTime);
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
        {
            enemyAction = 1;
            animator.SetBool("attack", false);
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
            navMeshAgent.speed = 10;
        }
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2f)
        {
            transform.position -= transform.forward * runSpeed * Time.deltaTime;
        }
    }

    private bool detectPlayer()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (Vector3.Distance(transform.position, playerPosition) < 5.0f)
        {
            return true;
        }
        var rayDirection = playerPosition - transform.position;
        Physics.Raycast(transform.position, rayDirection, out enemyEyes);
        if(enemyEyes.collider.tag == "Player")
        {
            Vector3 from = playerPosition - transform.position;
            Vector3 to = transform.forward;
            float angle = Vector3.Angle(from, to);
            if(angle < halfViewAngle)
            {
                return true;
            }
        }
        Debug.DrawLine(transform.position, enemyEyes.collider.transform.position, Color.red);
        return false;
    }

    private void eyesOnPlayer()
    {
        var relativepos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        var rotation = Quaternion.LookRotation(relativepos);
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
    }

    public void setAlive(bool a)
    {
        alive = a;  
    }

    public void decreaseHp(float x)
    {
        hp -= x;
    }

    public float getHp()
    {
        return hp;
    }
}
