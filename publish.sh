@echo off
echo building...
dotnet build -c Release
echo build complete!

echo Starting .NET Publish Process...

mkdir -p ./exes
mkdir -p ./dist/osx-x64 ./dist/osx-arm64 ./dist/linux-x64 ./dist/win-x64

#  Publish for macOS osx-x64
echo "Publishing for macOS (osx-x64)..."
dotnet publish -c Release -r osx-x64 --self-contained --output ./dist/osx-x64
echo Publish complete for macOS!

# Publish for macOS osx-arm64
echo "Publishing for macOS (osx-arm64)..."
dotnet publish -c Release -r osx-arm64 --self-contained --output ./dist/osx-arm64
echo Publish complete for macOS!

# Publish for Windows
echo "Publishing for Windows (win-x64)..."
dotnet publish -c Release -r win-x64 --self-contained --output ./dist/win-x64
echo Publish complete for Windows!

# Publish for Linux
echo "Publishing for Linux (linux-x64)..."
dotnet publish -c Release -r linux-x64 --self-contained --output ./dist/linux-x64
echo Publish complete for Linux!

echo "Creating tarballs..."
tar -czvf ./exes/coffee-shops-api-osx-x64.tar.gz -C ./dist/osx-x64 .
tar -czvf ./exes/coffee-shops-api-osx-arm64.tar.gz -C ./dist/osx-arm64 .
tar -czvf ./exes/coffee-shops-api-linux-x64.tar.gz -C ./dist/linux-x64 .

echo "Creating zip for Windows..."
tar -czvf ./exes/coffee-shops-api-win-x64.zip -C ./dist/win-x64 .
echo "Publish process complete!"


echo .NET Publish Process Complete!
