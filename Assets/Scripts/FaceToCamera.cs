using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{

    // public int GraspModel = 0;
    // Start is called before the first frame update

    Transform m_cam_main_Transform; // �����transform����
    public Vector3 m_Rot; // �ű���������ת�Ǳ��������ᴫ�ݸ�����
    public Vector3 m_Positon;// ������λ��
    public Vector3 m_cam_Rot; // ���������ת��
    public Vector3 m_Cam_Positon; //�������λ��
    public bool reverse = false;
    /// <summary>
    /// ��ʼ����ʱ���ʹ���������û�
    /// </summary>
    void Start()
    {
        m_cam_main_Transform = Camera.main.transform; //��������������
        m_Cam_Positon = m_cam_main_Transform.position;//����������λ��
        m_Positon = this.transform.position;//���������λ��
        Vector3 Dire = m_Cam_Positon - m_Positon; // ��������������ָ�������
        Dire = Dire.normalized; //��׼����ֻȡ�����ķ���
        if (reverse)
        {
            Dire = -Dire;
        }
        m_Rot = Dire; //�����ķ���Ϊ�����ķ���
        this.transform.forward = m_Rot; // �����ķ���ָ�������
    }
    // Update is called once per frame
    /// <summary>
    /// �������������������
    /// </summary>
    void Update()
    {
        // �ͳ�ʼ��һ��
        m_Cam_Positon = m_cam_main_Transform.position;
        m_Positon = this.transform.position;
        Vector3 Dire = m_Cam_Positon - m_Positon;
        Dire = Dire.normalized;
        if (reverse)
        {
            Dire = -Dire;
        }

        m_Rot = Dire;
        this.transform.forward = m_Rot; // �����ķ���ָ�������


    }


}
