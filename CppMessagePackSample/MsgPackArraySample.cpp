#include "MsgPackArraySample.h"
#include <msgpack.hpp>
#include <iostream>


size_t MsgPackArraySample::Serialize(char** serialized_data)
{
	size_t size = 0;
	/*
	mpack_writer_t writer;

	mpack_writer_init_growable(&writer, serialized_data, &size);

	mpack_build_array(&writer);
	mpack_write_bool(&writer, sample_data.compact);
	mpack_write_uint(&writer, sample_data.schema);
	mpack_complete_array(&writer);

	if (mpack_writer_destroy(&writer) != mpack_ok) {
		printf("An error occurred encoding the data!\n");
		return 0;
	}

	std::cout << "Serialized Array Format." << std::endl;
	*/
	return size;
}

bool MsgPackArraySample::Deserialize(const char* data, size_t size)
{
	/*
	mpack_tree_t tree;
	mpack_tree_init_data(&tree, data, size);
	mpack_tree_parse(&tree);

	const mpack_node_t root = mpack_tree_root(&tree);

	sample_data.compact = mpack_node_bool(mpack_node_array_at(root, 0));
	sample_data.schema = mpack_node_int(mpack_node_array_at(root, 1));
	*/
	return true;
}
