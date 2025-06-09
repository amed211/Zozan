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
                cout << "[✓] PID " << pid << " zaten izinli.\n";
                continue;
            }

            cout << "[!] Yeni shell işlemi tespit edildi (PID: " << pid << ")\n";

            if (controller.suspendProcess(pid)) {
                auto result = alert.promptUser("shell", pid);

                if (result == AlertSystem::UserResponse::Allow) {
                    whitelist.addToWhitelist(pid);
                    controller.resumeProcess(pid);
                    cout << "[+] Kullanıcı izin verdi, işlem devam etti.\n";
                } else {
                    controller.terminateProcess(pid);
                    cout << "[x] İşlem sonlandırıldı (kullanıcı ret veya zaman aşımı).\n";
                }
            } else {
                cout << "[!] İşlem askıya alınamadı.\n";
            }
        }

        this_thread::sleep_for(chrono::seconds(5));
    }

    return 0;
}
