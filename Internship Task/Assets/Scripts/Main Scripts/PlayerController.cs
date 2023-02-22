using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] enemies;
    public float detectionRange;
    public float safeDistance;
    public SphereGenrator spawnScript;
    public Color debugLineColor = Color.red;
    private LineRenderer lineRenderer;
    private Rigidbody playerRb;
    public float lineWidth = 0.1f;
    public float lineLength = 1f;
    public Vector3 direction;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerRb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        for (int i = 0; i < spawnScript.enemies.Length; i++)
        {
            enemies[i] = spawnScript.enemies[i];
        }
        
        // Check if any enemies are within detection range
        bool detected = false;
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= detectionRange)
            {
                detected = true;
                break;
            }
        }

        // If enemies are detected, move away from them
        if (detected)
        {
            direction = Vector3.zero;
            foreach (GameObject enemy in enemies)
            {
                
                if (Mathf.Abs(Vector3.Distance(transform.position, enemy.transform.position)) <= detectionRange)
                {
                    direction += (transform.position - enemy.transform.position).normalized;
                }
            }




            

            Debug.DrawLine(transform.position, transform.position + direction * 5f, debugLineColor);
            //playerRb.AddForce(direction * safeDistance * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.S)) {
            line();
            
        }
        else
        {
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
        }
    }

    void line()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction * 5f * lineLength);
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material.color = debugLineColor;
    }
}
