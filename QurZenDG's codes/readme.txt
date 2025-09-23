Please respect intellectual property rights
Many features have been removed from the shared code
The program is coded with Mono. The shared code has been stripped of all reverse engineering techniques and advanced features of the program

mcs -out:QurZenDG.exe -target:winexe \
  -r:System.Windows.Forms \
  -r:System.Drawing \
  Program.cs MainForm.cs Explorer.cs \
  Encryptor.cs Decryptor.cs AES.cs \
  PasswordStore.cs Security.cs \
  Prompt.cs LoadingForm.cs \
  EncryptContextMenu.cs
