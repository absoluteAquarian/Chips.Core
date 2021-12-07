:: This file is used by me to quickly copy the built files to the main Chips directory.  Must be run from the build directory: "Chips.Core/bin/Debug/net6.0/"
:: If you want to use this, just make sure that the directory that "Chips/" is located in is the same as the one for "Chips.Core/"

echo Copying Chips.Core to Chips project directory
:: Error codes less than 8 should just be ignored
(robocopy . ..\..\..\..\Chips Chips.Core.dll Chips.Core.pdb) ^& IF %ERRORLEVEL% LSS 8 SET ERRORLEVEL = 0