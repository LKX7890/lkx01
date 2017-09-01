#ifndef __USERTOKEN_POOL_H__
#define __USERTOKEN_POOL_H__

class UserTokenPool
{
public:
	UserTokenPool();
	~UserTokenPool();

	void PoolPop();
	void PoolPush();
	int PoolSize();
private:
	std::stack<UserToken> m_pool;
};
#endif
