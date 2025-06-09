#pragma once

#include <windows.h>
#include <iostream>

using namespace std;

class ProcessController {
public:
    bool suspendProcess(int pid);
    bool resumeProcess(int pid);
    bool terminateProcess(int pid);
};
