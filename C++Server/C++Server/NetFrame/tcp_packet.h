#ifndef KBE_SOCKETTCPPACKET_H
#define KBE_SOCKETTCPPACKET_H


class TCPPacket : public Packet
{
public:
	typedef KBEShared_ptr< SmartPoolObject< TCPPacket > > SmartPoolObjectPtr;
	static SmartPoolObjectPtr createSmartPoolObj();
	static ObjectPool<TCPPacket>& ObjPool();
	static TCPPacket* createPoolObject();
	static void reclaimPoolObject(TCPPacket* obj);
	static void destroyObjPool();

	static size_t maxBufferSize();

	TCPPacket(MessageID msgID = 0, size_t res = 0);
	virtual ~TCPPacket(void);

	int recvFromEndPoint(EndPoint & ep, Address* pAddr = NULL);

	virtual void onReclaimObject();
};

#endif // KBE_SOCKETTCPPACKET_H