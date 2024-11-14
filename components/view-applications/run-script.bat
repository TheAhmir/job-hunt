@echo off

:: Activate the virtual environment
call py-env\Scripts\activate.bat

:: Change to the application directory
cd /d .\components\view-applications

:: Run the Flask Python script
start /b python view-applications.py
start http://127.0.0.1:5000

:: Deactivate the virtual environment (optional - removing it)
:: Deactivation is not needed in the batch file, you can just exit the command prompt or close the terminal.
