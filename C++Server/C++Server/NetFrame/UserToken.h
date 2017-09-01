#ifndef __USER_TOKEN_H__
#define __USER_TOKEN_H__

#include "compat.h"
#include "tcp_packet.h"

class UserToken
{
public:

	UserToken(SOCKADDR socket);
	~UserToken();

private:
	// �û�����
	SOCKADDR m_socket;

	// �û�������������
	TCPPacket m_recv_packet;

	// �û�������������
	TCPPacket m_send_packet;
};

#endif // !__USER_TOKEN_H__
