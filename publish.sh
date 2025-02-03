@echo off
echo building...
dotnet build -c Release
echo build complete!

echo Starting .NET Publish Process...

mkdir -p ./exes/osx-x64 ./exes/osx-arm64 ./exes/win-x64 ./exes/linux-x64

#  Publish for macOS osx-x64
echo "Publishing for macOS (osx-x64)..."
dotnet publish -c Release -r osx-x64 --self-contained --output ./exes/osx-x64
echo Publish complete for macOS!

# Publish for macOS osx-arm64
echo "Publishing for macOS (osx-arm64)..."
dotnet publish -c Release -r osx-arm64 --self-contained --output ./exes/osx-arm64
echo Publish complete for macOS!

# Publish for Windows
echo "Publishing for Windows (win-x64)..."
dotnet publish -c Release -r win-x64 --self-contained --output ./exes/win-x64
echo Publish complete for Windows!

# Publish for Linux
echo "Publishing for Linux (linux-x64)..."
dotnet publish -c Release -r linux-x64 --self-contained --output ./exes/linux-x64
echo Publish complete for Linux!

echo "Creating tarballs..."
tar -czvf ./exes/cs-osx-x64.tar.gz -C ./exes/osx-x64 .
tar -czvf ./exes/cs-osx-arm64.tar.gz -C ./exes/osx-arm64 .
tar -czvf ./exes/cs-linux-x64.tar.gz -C ./exes/linux-x64 .

echo "Creating zip for Windows..."
tar -czvf ./exes/cs-win-x64.zip -C ./exes/win-x64 .
echo "Publish process complete!"


echo .NET Publish Process Complete!
