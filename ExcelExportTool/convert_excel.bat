
@echo off

set DATA_PATH=data
set SRC_PATH=src
set UNITY_DATACONFIG_PATH=../Assets/DataConfig

rd /s /q %DATA_PATH%
rd /s /q %SRC_PATH%
md %DATA_PATH%
md %SRC_PATH%


for /R "xls" %%i in (*.xls) do (
    echo %%i
    call python xls_deploy_tool.py %%~ni %%i
)

for /R "." %%i in (*.proto) do (
    echo %%~nxi
    call protogen %%~ni.proto --csharp_out=%SRC_PATH%
)

for /R "." %%i in (*.data) do (
    move %%i %DATA_PATH%
)

rd /s /q "%UNITY_DATACONFIG_PATH%"
md "%UNITY_DATACONFIG_PATH%"

xcopy /s /y /f "%SRC_PATH%"  "%UNITY_DATACONFIG_PATH%/%SRC_PATH%/"
xcopy /s /y /f "%DATA_PATH%" "%UNITY_DATACONFIG_PATH%/%DATA_PATH%/"

del tnt_*.*

@echo on

