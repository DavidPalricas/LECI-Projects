#!/bin/bash

cd ../src/

example1="../examples/ex01.agl"
example2="../examples/ex02.agl"
example3="../examples/ex03.agl"

echo "Which example you want to test?"
echo "1 - Example 1" 
echo "2 - Example 2"
echo "3 - Example 3"
echo "4 - All examples"

read example

case $example in
    1)
        echo "Testing example 1"
        antlr4-test $example1
        ;;
    2)
        echo 
        antlr4-test $example2
        ;;
    3)
        echo "Testing example 3"
        antlr4-test $example3
        ;;
 
    4)
        echo "Testing example 1"
        antlr4-test "$example1"
        echo "Testing example 2"
        antlr4-test "$example2"
        echo "Testing example 3"
        antlr4-test "$example3"
        ;;

       *)
        echo "Invalid option"
        ;;
esac