using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeMech {
    void CheckLevelState();//doesn't yet support default implementation
    void Slow();
    void Stop();
    void Restore();
}

[System.Serializable] //necessary to be able to expose in the inspector
public struct TimeVar : ITimeMech {
    
    public float originalSpeed;
    public float halfSpeed;
    public static float stopped = 0f;

    public float currentSpeed;

    public void CheckLevelState()
    {
        switch (LevelManager.levelTime)
        {
            case LevelTimeState.Normal: Restore(); break;
            case LevelTimeState.Slowed: Slow(); break;
            case LevelTimeState.Stopped: Stop(); break;
            default: break;
        }
    }

    public void Slow() { if (currentSpeed != this.halfSpeed) currentSpeed = this.halfSpeed; }
    public void Stop() { if (currentSpeed != TimeVar.stopped) currentSpeed = TimeVar.stopped; }
    public void Restore() { if (currentSpeed != this.originalSpeed) currentSpeed = this.originalSpeed; }
}