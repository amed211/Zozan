# Zozan
This program prevents hackers from executing code remotely on your device. THIS IS ONLY A BETA VERSION

This program is an enhanced iteration of the beta version, and active development is ongoing. Should you have any questions, please send them to mobil.uygulama.404@gmail.com. It was compiled using x86_64-w64-mingw32-g++, but Visual Studio is also an option for compilation. A ready-to-use .exe is included. You can also explore older versions in the releases section if you like. This program is still very much in development...

The compilation command for the program is:

x86_64-w64-mingw32-g++ main.cpp ProcessWatcher.cpp ProcessController.cpp AlertSystem.cpp WhitelistManager.cpp -o monitor.exe -mwindows -static





https://github.com/user-attachments/assets/24134668-2851-4939-946b-3af7f4c2e400

The delay in detection is because the main.cpp file checks every 5 seconds.
