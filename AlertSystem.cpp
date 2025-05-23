#include "AlertSystem.h"
#include <iostream>

bool AlertSystem::promptUser(const string& exeName, int pid) {
    cout << "[?] Yeni " << exeName << " oturumu tespit edildi (PID: " << pid << ")\n";
    cout << "    Devam etmesine izin verilsin mi? (e/h): ";
    char cevap;
    cin >> cevap;
    return (cevap == 'e' || cevap == 'E');
}
