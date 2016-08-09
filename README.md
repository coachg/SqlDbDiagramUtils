# SqlDbDiagramUtils
Simple command line utility to export and import SQL Server database diagrams

# Example Commands
--ExportDiagram -S [YourDbServer] -D [YourDb] -M [YourDbDiagram] -P "C:\Temp\YourDbDiagram.dat"

--ImportDiagram -S [YourDbServer] -D [YourDb] -M [YourDbDiagram] -P "C:\Temp\YourDbDiagram2.dat"

# Credits
This project uses the following NuGet packages
Dapper
https://www.nuget.org/packages/Dapper
https://github.com/StackExchange/dapper-dot-net

CommandLineParser
https://www.nuget.org/packages/CommandLineParser/
https://github.com/gsscoder/commandline

