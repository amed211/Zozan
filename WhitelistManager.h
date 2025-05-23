#pragma once

#include <unordered_set>

using namespace std;

class WhitelistManager {
public:
    bool isWhitelisted(int pid);
    void addToWhitelist(int pid);

private:
    unordered_set<int> whitelist;
};
