@ECHO OFF

title installing sql server

docker pull mcr.microsoft.com/mssql/server:2019-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=mudar123@mudar123" -p 1401:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2019-latest
