REM This script performs cleanup tasks on a Windows system to optimize disk space.
 
@ECHO OFF
 
REM Delete files in %userprofile%\Recent for all users
FOR /D /r "C:\Users" %%G IN (*) DO (
    del /s /f /q "%%G\Recent\*.*" 2>nul
)
 
REM Delete files in %userprofile%\Documents\Exports for all users
FOR /D /r "C:\Users" %%G IN (*) DO (
    del /s /f /q "%%G\Documents\Exports\*.*" 2>nul
)
 
REM Delete files in C:\Windows\Prefetch
del /s /f /q "C:\Windows\Prefetch\*.*" 2>nul
 
REM Delete files in C:\Windows\Temp
del /s /f /q "C:\Windows\Temp\*.*" 2>nul
 
REM Delete files in %USERPROFILE%\AppData\Local\Temp for all users
FOR /D /r "C:\Users" %%G IN (*) DO (
    del /s /f /q "%%G\AppData\Local\Temp\*.*" 2>nul
)
 
REM Delete files in %SystemRoot%\Temp for all users
del /s /f /q "%SystemRoot%\Temp\*.*" 2>nul
 
REM Delete Teams appdata for all users
FOR /D /r "C:\Users" %%G IN (*) DO (
    rmdir /s /q "%%G\AppData\Roaming\Microsoft\Teams" 2>nul
    rmdir /s /q "%%G\AppData\Local\Microsoft\Teams" 2>nul
)
 
REM Clean up Windows Update files
net stop wuauserv
rmdir /s /q %windir%\SoftwareDistribution\Download
net start wuauserv
 
REM Empty Recycle Bin for all users
FOR /D /r "C:\Users" %%G IN (*) DO (
    rd /s /q "%%G\$Recycle.Bin" 2>nul
)

ECHO Cleanup completed.