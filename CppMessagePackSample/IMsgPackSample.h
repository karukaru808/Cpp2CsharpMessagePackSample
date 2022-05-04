#pragma once
#include "MsgPackSampleData.h"

class IMsgPackSample
{
public:
	IMsgPackSample() = default;
	IMsgPackSample(const bool compact, const int schema) { sample_data.compact = compact; sample_data.schema = schema; }
	virtual ~IMsgPackSample() = default;

	virtual size_t Serialize(char** serialized_data) = 0;
	virtual bool Deserialize(const char* data, size_t size) = 0;

	MsgPackSampleData sample_data;
};
