﻿using UnityEngine;


// 一个坦克的移动包含以下属性:
// 1.是否移动 m_MoveStatus;
// 2.移动方向 m_MoveDirect
//
public class TankEntity : MonoBehaviour {

    public int _id;
    private Vector3 m_MoveDirect;
    private TankMoveStatus m_MoveStatus = TankMoveStatus.Stopped;
    private TankRole m_Role = TankRole.Main;

    public void Start() {
        _id = Random.Range(0, 10000);
        Invoke("SyncTank", 2);
    }

    public void SyncTank() {
        if(m_Role != TankRole.Main) {
            return;
        }

        var t = new Tank();
        t.Id = _id;
        t.Position = transform.position;
        t.MoveStatus = (int)m_MoveStatus;
        t.MoveDirect = m_MoveDirect;
        NetSocket.Instance.Send<Tank> ("SyncTank", t);
    }

    // 设置移动状态
    public void SetMoveStatus(TankMoveStatus status) {
        m_MoveStatus = status;
        SyncTank();
    }

    // 设置移动方向
    public void SetMoveDirect(Vector3 direct) {
        m_MoveDirect = direct;
        SyncTank();
    }

    public void SetTankId(int id) {
        _id = id;
    }

    public void SetTankRole(TankRole role) {
        m_Role = role;
    }

    // 固定移动
    public void FixedUpdate() {
        if (m_MoveStatus == TankMoveStatus.Moving) {
            transform.LookAt(transform.position + m_MoveDirect);
            transform.Translate(Vector3.forward * Time.deltaTime *5);
        }
    }

}