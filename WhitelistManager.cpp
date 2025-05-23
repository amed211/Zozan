#include "WhitelistManager.h"

bool WhitelistManager::isWhitelisted(int pid) {
    return whitelist.find(pid) != whitelist.end();
}

void WhitelistManager::addToWhitelist(int pid) {
    whitelist.insert(pid);
}
