gcc -shared -o TestC.dll TestC.c

dotnet build

dotnet Interoperability/bin/Debug/netcoreapp3.1/Interoperability.dll
