#pragma once
#include "IMsgPackSample.h"

class MsgPackMapSample final : public IMsgPackSample
{
public:
	MsgPackMapSample() : IMsgPackSample() {}
	MsgPackMapSample(const bool compact, const int schema) : IMsgPackSample(compact, schema) {}

	size_t Serialize(char** serialized_data) override;
	bool Deserialize(const char* data, size_t size) override;
};
