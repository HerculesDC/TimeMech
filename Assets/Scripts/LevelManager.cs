using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelTimeState { Stopped, Slowed, Normal }
public class LevelManager : MonoBehaviour, ITimeMech
{
    //Think through.
    [SerializeField] private float m_maxStopTime, m_maxStopCooldown;
    private float m_stopTime, m_stopCooldown;

    [SerializeField] private float m_maxSlowTime, m_maxSlowCooldown;
    private float m_slowTime, m_slowCooldown;

    private static LevelTimeState levelInnerTime;
    public static LevelTimeState levelTime { get { return levelInnerTime; } }
    private bool m_isStopped, m_isSlow;
    //private ITimeMech[] timeManageables;

    void Awake() {
        m_slowTime = m_stopTime = 0;
        levelInnerTime = LevelTimeState.Normal;
        m_isStopped = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //timeManageables = FindObjectsOfType<ITimeMech>();
    }

    // Update is called once per frame
    void Update()
    {
        //Time Stop toggle
        if (Input.GetKeyDown(KeyCode.Keypad1)) {  m_isStopped = !m_isStopped; }

        if (m_isStopped) { Stop(); }
        else {
            m_isSlow = Input.GetKey(KeyCode.Keypad0);
            if (m_isSlow) { Slow(); }
            else { Restore(); }
        }
    }
    public void CheckLevelState() { }

    public void Slow() { //Slow should not overcome Stop
        if (levelInnerTime == LevelTimeState.Normal) {
            levelInnerTime = LevelTimeState.Slowed;
        }
    }
    public void Restore() {
        //This allows Stop-to-Slow return
        if (m_isSlow) { levelInnerTime = LevelTimeState.Slowed; }
        else { levelInnerTime = LevelTimeState.Normal; }
    }

    public void Stop() {
        if (levelInnerTime != LevelTimeState.Stopped) {
            levelInnerTime = LevelTimeState.Stopped;
        }
    }
}
