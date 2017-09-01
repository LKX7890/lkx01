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
	// 用户连接
	SOCKADDR m_socket;

	// 用户接受网络数据
	TCPPacket m_recv_packet;

	// 用户发送网络数据
	TCPPacket m_send_packet;
};

#endif // !__USER_TOKEN_H__
