using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siner : MonoBehaviour
{
    [SerializeField] private TimeVar m_t;
    [SerializeField] private float m_amplitude;
    private float m_angle;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        m_t.CheckLevelState();
        
        m_angle += m_t.currentSpeed*Time.deltaTime;

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 
                                                         m_amplitude * Mathf.Sin(m_angle),
                                                         this.gameObject.transform.position.z);
        
    }
}
