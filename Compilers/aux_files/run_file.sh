#!/bin/bash
echo "Insert the name of the file you want to run"
read file_name

echo "Running antlr4-run $file_name "

cd ../src/

antlr4-run "../aux_files/$file_name" "$@"