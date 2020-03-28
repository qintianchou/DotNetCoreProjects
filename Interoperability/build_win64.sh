gcc -shared -o TestC.dll TestC.c

dotnet build

bin_path=Interoperability/bin/Debug/netcoreapp3.1/

mv TestC.dll $bin_path

cd $bin_path

dotnet Interoperability.dll

echo exit code: $?
