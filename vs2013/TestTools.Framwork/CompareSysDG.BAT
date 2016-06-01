@echo off&color 02

@set PATH=C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE;
echo %PATH%
MSTest /testcontainer:C:\Automation\TestTools\ExecutableFile\TestTools.Framwork.dll /test:TestTools.Framwork.TestTools.CompareSysDevGroup
