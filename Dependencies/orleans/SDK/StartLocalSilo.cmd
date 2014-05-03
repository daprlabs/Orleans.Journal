@setlocal
@echo off
@if NOT "%ECHO%"=="" @echo %ECHO%

set CMDHOME=%~dp0.

set LOCAL_SILO_HOME=%CMDHOME%\LocalSilo

@echo == Starting Orleans local silo in %LOCAL_SILO_HOME%

set LOCAL_SILO_EXE=%LOCAL_SILO_HOME%\OrleansHost.exe
set LOCAL_SILO_PARAMS=Primary
@REM set LOCAL_SILO_PARAMS=%LOCAL_SILO_PARAMS% DeploymentGroup=face5b8aac1c4bf89f39d26fd3d3face

cd "%LOCAL_SILO_HOME%"
"%LOCAL_SILO_EXE%" %LOCAL_SILO_PARAMS% %*
