@setlocal
@echo OFF

set CMDHOME=%~dp0

set o_node=Primary
if not "%1" == "" (
    set o_node=%1
)

@echo -- Starting Orleans node "%o_node%" on localhost
cd %CMDHOME% && OrleansHost.exe %o_node%
