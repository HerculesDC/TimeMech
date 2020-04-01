using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    [SerializeField] private TimeVar m_t;
    void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_t.CheckLevelState();

        this.gameObject.transform.Rotate(Vector3.up * m_t.currentSpeed * Time.deltaTime);
    }
}
