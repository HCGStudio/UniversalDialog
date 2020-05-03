function downloadAndCheckHash {
    param($fileName, $link, $hash)
    if ([String]::IsNullOrEmpty($link) -or [String]::IsNullOrEmpty($hash)) {
        Write-Output "Link and hash is required"
        return;
    }
    Write-Output ("Downloading " + $fileName)
    Invoke-WebRequest $link -OutFile (".\UniversalDialog\" + $fileName)
    $downloadedHash = Get-FileHash (".\UniversalDialog\" + $fileName)
    if ($downloadedHash.Hash -ne $hash) {
        Write-Output ("File " + $fileName + " verified failed, hash was " + $downloadedHash.Hash + ", but required was " + $hash)
    }
    else {
        Write-Output ("File " + $fileName + " hash verified success, was " + $hash)
    }
}

downloadAndCheckHash libUniversalDialogCocoaBinding.dylib "https://github.com/HCGStudio/UniversalDialogCocoaBinding/releases/download/v1.0.0/libUniversalDialogCocoaBinding.dylib" EDA9AE62EB782710A14063FBD8C91F1CBF3719FAB07C2BACDA539CD38C787F28
downloadAndCheckHash libUniversalDialogQtBinding.so "https://github.com/HCGStudio/UniversalDialogQtBinding/releases/download/v1.0.0/libUniversalDialogQtBinding.so" 454D5547D4F8F36697A9E6E12B6B3F1D5811E3C95E08B589B4DE3FE5FEDD07C1