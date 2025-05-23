#pragma once

#include <vector>
#include <string>
#include <windows.h>
#include <tlhelp32.h>

using namespace std;

class ProcessWatcher {
public:
    ProcessWatcher();
    vector<int> detectShellProcesses(); // Yeni powershell/cmd işlemlerini döndürür
private:
    vector<int> knownPIDs;
    bool isTargetProcess(const string& exeName);
    bool isKnownPID(int pid);
};
