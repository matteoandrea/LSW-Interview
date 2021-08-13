@ECHO OFF

TITLE Clear Project Folder

setlocal

echo All files in the list will be deleted
echo Library\
echo Temp\
echo Logs\
echo obj\
echo *.sln
echo *.csproj

:PROMPT
SET /P AREYOUSURE=Are you sure (Y/[N])?
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

CLS

SET MSGSUCESS=was successfully deleted...
SET MSGFAIL=has already been deleted or does not exist...
SET FOLDER=%CD%\

:LIBDEL
SET LIBFOLDER=Library
IF exist %FOLDER%%LIBFOLDER% (
    rmdir %FOLDER%%LIBFOLDER% /s /q
    echo %LIBFOLDER% %MSGSUCESS%
) ELSE (
    echo %LIBFOLDER% %MSGFAIL%
)

:TEMPDEL
SET TEMPFOLDER=Temp
IF exist %FOLDER%%TEMPFOLDER% (
    rmdir %FOLDER%%TEMPFOLDER% /s /q
    echo %TEMPFOLDER% %MSGSUCESS%
) ELSE (
    echo %TEMPFOLDER% %MSGFAIL%
)

:LOGDEL
SET LOGFOLDER=Logs
IF exist  %FOLDER%%LOGFOLDER% (
    rmdir %FOLDER%%LOGFOLDER% /s /q
    echo %LOGFOLDER% %MSGSUCESS%
) ELSE (
    echo %LOGFOLDER% %MSGFAIL%
)

:OBJDEL
SET OBJFOLDER=obj
IF exist %FOLDER%%OBJFOLDER% (
    rmdir %FOLDER%%OBJFOLDER% /s /q
    echo %OBJFOLDER% %MSGSUCESS%
) ELSE (
    echo %OBJFOLDER% %MSGFAIL%
)

:SLNDEL
SET SLNFILE=*.sln
IF exist %FOLDER%%SLNFILE% (
    del -f %FOLDER%%SLNFILE%
    echo %SLNFILE% %MSGSUCESS%
) ELSE (
    echo %SLNFILE% %MSGFAIL%
)

:CSPROJDEL
SET CSPROJFILE=*.csproj
IF exist %FOLDER%%CSPROJFILE% (
    del -f %FOLDER%%CSPROJFILE%
    echo %CSPROJFILE% %MSGSUCESS%
) ELSE (
    echo %CSPROJFILE% %MSGFAIL%
)

PAUSE

:END
endlocal
