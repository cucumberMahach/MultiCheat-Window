string bat = @"echo wscript.Sleep 1000>""%temp%\sleep1.vbs"" 
                cscript //nologo ""%temp%\sleep1.vbs"" 
                del ""%temp%\sleep1.vbs""
                taskkill /f /im ""yourfilename""
                del ""yourfilename""
                rename ""multicheat.dat"" ""yourfilename""
                del ""update.bat""
                ".Replace("yourfilename", yourFileName);