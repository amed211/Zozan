#include "ProcessWatcher.h"
#include <iostream>
#include <algorithm>

ProcessWatcher::ProcessWatcher() {
    // Başlangıçta bilinen PID'leri yükle (boş olabilir)
}

bool ProcessWatcher::isTargetProcess(const string& exeName) {
    // Hedef işlemler: powershell.exe ve cmd.exe
    string lowerName = exeName;
    transform(lowerName.begin(), lowerName.end(), lowerName.begin(), ::tolower);
    return lowerName == "powershell.exe" || lowerName == "cmd.exe";
}

bool ProcessWatcher::isKnownPID(int pid) {
    return find(knownPIDs.begin(), knownPIDs.end(), pid) != knownPIDs.end();
}

vector<int> ProcessWatcher::detectShellProcesses() {
    vector<int> newPIDs;

    HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (snapshot == INVALID_HANDLE_VALUE) {
        cerr << "[!] Process snapshot alınamadı.\n";
        return newPIDs;
    }

    PROCESSENTRY32 pe;
    pe.dwSize = sizeof(PROCESSENTRY32);

    if (Process32First(snapshot, &pe)) {
        do {
            string exeName = pe.szExeFile;
            int pid = pe.th32ProcessID;

            if (isTargetProcess(exeName) && !isKnownPID(pid)) {
                cout << "[+] Yeni hedef işlem bulundu: " << exeName << " (PID: " << pid << ")\n";
                knownPIDs.push_back(pid);
                newPIDs.push_back(pid);
            }

        } while (Process32Next(snapshot, &pe));
    }

    CloseHandle(snapshot);
    return newPIDs;
}
