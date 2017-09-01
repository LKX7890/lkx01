#ifndef KBE_SOCKETPACKET_H
#define KBE_SOCKETPACKET_H

class Packet
{
public:
	Packet(MessageID msgID = 0, bool isTCPPacket = true, size_t res = 200) :
		msgID_(msgID),
		sentSize(0)
	{
	};

	virtual ~Packet(void)
	{
	};

	virtual size_t getPoolObjectBytes()
	{
		size_t bytes = sizeof(msgID_) + sizeof(isTCPPacket_) + sizeof(encrypted_) + sizeof(pBundle_)
			+ sizeof(sentSize);

		return MemoryStream::getPoolObjectBytes() + bytes;
	}

	virtual bool empty() const { return length() == 0; }

	void resetPacket(void)
	{
		sentSize = 0;
		msgID_ = 0;
		// memset(data(), 0, size());
	};

	inline void messageID(MessageID msgID) {msgID_ = msgID;}

	inline MessageID messageID() const { return msgID_; }

	void isTCPPacket(bool v) { isTCPPacket_ = v; }
	bool isTCPPacket() const { return isTCPPacket_; }

	bool encrypted() const { return encrypted_; }

	void encrypted(bool v) { encrypted_ = v; }


protected:
	MessageID msgID_;

public:
	uint32 sentSize;

};

#endif // KBE_SOCKETPACKET_H
