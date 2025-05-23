#pragma once

#include <string>

using namespace std;

class AlertSystem {
public:
    bool promptUser(const string& exeName, int pid);
};
