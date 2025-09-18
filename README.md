# QurZen Framework - Beta Version 1

QurZen is an internal security system framework currently under development to protect against malware. It features a modular architecture, ensuring that if one module is terminated, other modules continue to operate, significantly complicating attack processes.

**Important Note:** QurZen is a commercial product that is not yet ready for sale.

## Overview

The goal of QurZen is not to prevent malware from infiltrating the system, but rather to prevent infiltrated malware from operating within the device.

Please note that QurZen is still in active development and is not limited to just these two files. There are 11 additional modules planned for integration into the program.

QurZen is **not** an antivirus or firewall - it's an endpoint defense system consisting of multiple programs that operate independently while monitoring each other. **IT IS STILL IN DEVELOPMENT PHASE.**

The system is primarily targeted at government agencies and corporations, but is also suitable for individual use.

## Current Modules

### QurZen1.exe (Module 1)
The first module is designed to prevent remote code execution on your device. The current beta version can detect code running under protected processes but cannot block it. The original QurZen1.exe can detect and stop suspicious code even in system processes.

### QurZenDG.exe (Module 2)
This is QurZen's second module, responsible for encrypting and protecting important files on your device **(MORE FEATURES TO BE ADDED)**. This way, even if your data is stolen, it remains protected by military-grade encryption algorithms, leaving attackers with only encrypted data that they cannot sell or use for extortion.

The original module provides data pool security against password theft. This means that if your password is stolen, another QurZenDG instance cannot decrypt the data - **ONLY THE COPY THAT ENCRYPTED THE DATA CAN DECRYPT IT, NO OTHER COPY CAN**. However, this feature will only be available in the original versions and is not present in the currently shared version.

### Modules 3 & 4
Module 3's programming process is currently suspended. Module 4 is not yet completed and therefore has not been released.

## Frequently Asked Questions

**Q: QurZen1.exe is flagged as suspicious on VirusTotal**
**A:** QurZen is an unsigned program that monitors all system processes and can intervene, causing it to be flagged as suspicious. Users can test it in virtual machines if desired.

**Q: QurZen1.exe module keeps giving warnings**
**A:** If it continuously gives warnings, this indicates the presence of an abnormal situation on your device.

**Q: Why don't they start automatically at startup?**
**A:** Remember, this is only a beta version, not the completed original version.

**Q: I forgot my file password**
**A:** **TOUGH LUCK!!!**

**Q: Can I use these two files permanently?**
**A:** You can use QurZenDG permanently, but Module 1 is non-functional alone and requires other modules.

**Q: What happens if I delete the password.txt.zoz file?**
**A:** If you remember the password, no need to worry. Create a new folder, encrypt it with the same password, and a new password.txt.zoz file will be created. Copy this file to the folder containing your data and re-access the folder using Module 2.

**Q: How can I encrypt files?**
**A:** Put all files you want to encrypt in a folder, then use Module 2 to **GO TO ONE LEVEL ABOVE THE FOLDER** - don't go into the folder, stay one level up. Then right-click on the folder you want to encrypt, click the button that appears, and set your password.

**Q: I want to remove the password from an encrypted folder, how can I do this?**
**A:** Access the folder using QurZen, enter the password, then enter the folder normally and delete the password.txt file. The folder will no longer be encrypted.

**Q: The subfolders of the encrypted folder are also encrypted, what can I do?**
**A:** Don't worry, subfolders are encrypted with the same password.

**Q: QurZen1 consumes too much CPU, what's the reason?**
**A:** It monitors the entire system looking for suspicious activity and does this 30 times per second.

**Q: Do you have an email address we can reach you at?**
**A:** Yes, but I may respond late. Email address: uerboga7@gmail.com

## Development Status

QurZen is a framework consisting of multiple programs working together. The currently released versions are completely manual and shared only to evaluate user feedback.

## Disclaimer

This software is in beta testing phase. Use at your own risk. The developer is not responsible for any data loss or system damage.

---

*For more information and updates, please contact the developer via the provided email address.*
