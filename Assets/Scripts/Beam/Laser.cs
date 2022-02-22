using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootLaser();
    }

    void shootLaser(){
        if(Physics2D.Raycast(m_transform.position, transform.right)){
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            draw2DRay(laserFirePoint.position, _hit.point);
        }else{
            draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void draw2DRay(Vector2 startPos, Vector2 endPos){
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
