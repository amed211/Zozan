#include "ProcessController.h"
#include <tlhelp32.h>

bool ProcessController::suspendProcess(int pid) {
    HANDLE hThreadSnap = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
    if (hThreadSnap == INVALID_HANDLE_VALUE) {
        cerr << "[!] Thread snapshot alınamadı.\n";
        return false;
    }

    THREADENTRY32 te;
    te.dwSize = sizeof(THREADENTRY32);

    if (!Thread32First(hThreadSnap, &te)) {
        CloseHandle(hThreadSnap);
        return false;
    }

    do {
        if (te.th32OwnerProcessID == pid) {
            HANDLE hThread = OpenThread(THREAD_SUSPEND_RESUME, FALSE, te.th32ThreadID);
            if (hThread != NULL) {
                SuspendThread(hThread);
                CloseHandle(hThread);
            }
        }
    } while (Thread32Next(hThreadSnap, &te));

    CloseHandle(hThreadSnap);
    cout << "[*] PID " << pid << " askıya alındı.\n";
    return true;
}

bool ProcessController::resumeProcess(int pid) {
    HANDLE hThreadSnap = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
    if (hThreadSnap == INVALID_HANDLE_VALUE) {
        cerr << "[!] Thread snapshot alınamadı.\n";
        return false;
    }

    THREADENTRY32 te;
    te.dwSize = sizeof(THREADENTRY32);

    if (!Thread32First(hThreadSnap, &te)) {
        CloseHandle(hThreadSnap);
        return false;
    }

    do {
        if (te.th32OwnerProcessID == pid) {
            HANDLE hThread = OpenThread(THREAD_SUSPEND_RESUME, FALSE, te.th32ThreadID);
            if (hThread != NULL) {
                ResumeThread(hThread);
                CloseHandle(hThread);
            }
        }
    } while (Thread32Next(hThreadSnap, &te));

    CloseHandle(hThreadSnap);
    cout << "[*] PID " << pid << " yeniden çalıştırıldı.\n";
    return true;
}

bool ProcessController::terminateProcess(int pid) { // Bu bölüm sonradan eklendi
    HANDLE hProcess = OpenProcess(PROCESS_TERMINATE, FALSE, pid);
    if (hProcess == NULL) return false;

    BOOL result = TerminateProcess(hProcess, 1);
    CloseHandle(hProcess);

    return result;
}
    } while (Thread32Next(hThreadSnap, &te));

    CloseHandle(hThreadSnap);
    cout << "[*] PID " << pid << " yeniden çalıştırıldı.\n";
    return true;
}
