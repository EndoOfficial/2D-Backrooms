using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Raycast : MonoBehaviour
{
    public GameObject wallHitPref;
    public GameObject EnemyHitPref;
    public float shrinkTime = 1f;


    [SerializeField] private LayerMask layerMask;
    
    private float fov;
    public float viewDistance = 1f;
    private float startingAngle;
    public bool spacePressed;

    private void Start()
    {
        fov = 360f;
        LeanTween.init(10000);
    }

    // Update is called once per frame
    void Update()
    {
        int rayCount = 250;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle(angle), viewDistance);
            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = transform.position + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // Hit object
                if (Input.GetKeyDown("space"))
                {
                    spacePressed = true;
                    Events.onSpacePressed?.Invoke(spacePressed);
                    vertex = raycastHit2D.point;
                    if (!raycastHit2D.transform.gameObject.CompareTag("blip"))
                    {
                        GameObject newblip = Instantiate(wallHitPref);
                        newblip.transform.position = new Vector3(vertex.x, vertex.y, vertex.z - 1);
                        LeanTween.scale(newblip, Vector3.zero, shrinkTime)
                                .setEaseInCubic()
                                .setOnComplete(() => Destroy(newblip));
                    }
                }
            }
            angle -= angleIncrease;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle(angle), viewDistance);
            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = transform.position + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
                Debug.Log("no hit");

            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;
                Gizmos.DrawLine(transform.position, vertex);
            }
            angle -= angleIncrease;
        }
    }
}
