#include <iostream>
#include <thread>
#include <chrono>
#include "ProcessWatcher.h"
#include "ProcessController.h"
#include "AlertSystem.h"
#include "WhitelistManager.h"

using namespace std;

void printHeader() {
    cout << "-----------------------------------\n";
    cout << "  Güvenlik İzleyicisi Başlatıldı\n";
    cout << "-----------------------------------\n";
}

int main() {
    printHeader();

    ProcessWatcher watcher;
    ProcessController controller;
    AlertSystem alert;
    WhitelistManager whitelist;

    while (true) {
        vector<int> newShells = watcher.detectShellProcesses();

        for (int pid : newShells) {
            if (whitelist.isWhitelisted(pid)) {
                cout << "[✓] PID " << pid << " zaten izinli, işlem devam ediyor.\n";
                continue;
            }

            cout << "[!] Yeni shell işlemi tespit edildi (PID: " << pid << ")\n";

            // İşlemi askıya al
            if (controller.suspendProcess(pid)) {
                // Kullanıcıdan onay al
                if (alert.promptUser("shell", pid)) {
                    whitelist.addToWhitelist(pid);
                    controller.resumeProcess(pid);
                } else {
                    cout << "[x] Kullanıcı işlemi reddetti, işlem askıda kalacak.\n";
                }
            } else {
                cout << "[!] İşlem askıya alınamadı, muhtemelen yetki yetersiz.\n";
            }
        }

        this_thread::sleep_for(chrono::seconds(5));
    }

    return 0;
}
