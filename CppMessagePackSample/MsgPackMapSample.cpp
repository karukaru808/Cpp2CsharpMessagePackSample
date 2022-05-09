#include "MsgPackMapSample.h"
#include <msgpack.hpp>
#include <iostream>


size_t MsgPackMapSample::Serialize(char** serialized_data)
{
	size_t size = 0;

	/*
	mpack_writer_t writer;

	mpack_writer_init_growable(&writer, serialized_data, &size);

	mpack_build_map(&writer);
	mpack_write_cstr(&writer, "compact");
	mpack_write_bool(&writer, sample_data.compact);
	mpack_write_cstr(&writer, "schema");
	mpack_write_int(&writer, sample_data.schema);
	mpack_complete_map(&writer);

	if (mpack_writer_destroy(&writer) != mpack_ok) {
		printf("An error occurred encoding the data!\n");
		return 0;
	}

	std::cout << "Serialized Map Format." << std::endl;
	*/
	return size;
}

bool MsgPackMapSample::Deserialize(const char* data, const size_t size)
{
	/*
	mpack_tree_t tree;
	mpack_tree_init_data(&tree, data, size);
	mpack_tree_parse(&tree);

	const mpack_node_t root = mpack_tree_root(&tree);

	sample_data.compact = mpack_node_bool(mpack_node_map_cstr(root, "compact"));
	sample_data.schema = mpack_node_int(mpack_node_map_cstr(root, "schema"));
	*/
	return true;
}

