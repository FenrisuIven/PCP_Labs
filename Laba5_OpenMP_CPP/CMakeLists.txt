cmake_minimum_required(VERSION 3.29)
project(Laba5_OpenMP_CPP)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11 -fopenmp")

add_executable(Laba5_OpenMP_CPP main.cpp)
