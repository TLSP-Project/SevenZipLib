del 7Zip\CPP\7zip\Bundles\Alone2\b\m_arm64\7zz.dylib
del 7Zip\CPP\7zip\Bundles\Alone2\b\m_x64\7zz.dylib
copy "7Zip\CPP\7zip\Bundles\Alone2\b\m_arm64\7zz.so" "7Zip\CPP\7zip\Bundles\Alone2\b\m_arm64\7zz.dylib"
copy "7Zip\CPP\7zip\Bundles\Alone2\b\m_x64\7zz.so" "7Zip\CPP\7zip\Bundles\Alone2\b\m_x64\7zz.dylib"
nuget pack SevenZipLib.nuspec