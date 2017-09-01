// TSocket.h: interface for the TSocket class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_TSOCKET_H__ECFF7A02_DCAF_455D_97C3_0C1D465D977B__INCLUDED_)
#define AFX_TSOCKET_H__ECFF7A02_DCAF_455D_97C3_0C1D465D977B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#pragma comment(lib,"ws2_32.lib")

#define WM_RECVDATA WM_USER+500 //������յ����ݷ�������Ϣ��
#define MAX_MSG_LEN 1500 //������Ϣ����(MTU)
#define DEFAULTPORT 1991 //����Ĭ�Ϸ���˿�

class TSocket;

struct RECVPARAM
{
	TSocket* psocket;//ָ��������socket
	HWND hwnd;//ָ����Ҫ���������Ϣ�Ĵ��ھ��
};

class TSocket
{
public:
	TSocket();
	virtual ~TSocket();

public:
	//����Winsock��
	BOOL LoadSocket();
	BOOL CreateSocketSer(BOOL bMode);//����socket���ڷ�������
	SOCKET CreateSocket(BOOL bMode);//����socket���ڿͻ���
	BOOL BingSocket(u_long ulIP = 0, u_short usPort = DEFAULTPORT);//�󶨶˿ڡ�IP(Ĭ������IP)
	BOOL Start(RECVPARAM* recvPar);
	BOOL Stop();
	SOCKET GetSocket();//�õ���ǰsocket
	CString m_strData;//����ȥ������

	BOOL m_bIsRun; //�Ƿ��������

	u_long m_ulLocalIP;//����IP
	u_short m_usLocalPort;//���ض˿�
	u_long m_ulRemoteIP;//Զ��IP
	u_short m_usRemotePort;//Զ�̶˿�

	//��������
	DWORD SendData(CString strSend);
	//TCP�����߳�
	static DWORD WINAPI TcpSendProc(LPVOID lpParameter);
	//UDP�����߳�
	static DWORD WINAPI UdpSendProc(LPVOID lpParameter);
	//TCP��������
	DWORD TcpSend();
	//UDP��������
	DWORD UdpSend();

private:
	BOOL m_bMode; //ͨ�ŷ�ʽ 1--TCP 0--UDP
	SOCKET m_socket;//�׽���
	HANDLE m_hRecv; //�����̵߳ľ��

	//TCP�����߳�
	static DWORD WINAPI TcpRecvProc(LPVOID lpParameter);
	//UDP�����߳�
	static DWORD WINAPI UdpRecvProc(LPVOID lpParameter);

};

#endif // !defined(AFX_TSOCKET_H__ECFF7A02_DCAF_455D_97C3_0C1D465D977B__INCLUDED_)