# N5Challenge

Project for registering user permissions.

## Install prerequisite software

This project assumes you're using either Windows 11.

Make sure you have the following software installed:

1. Docker for Windows
1. Windows Subsystem for Linux (WSL) with Ubuntu 18.04
1. Visual Studio Code

## Technologies and frameworks used:
- .Net Core 3.1
- EF Core
- Elastic Search
- React
- Docker

## Steps to run project (development only):

First build container:
```
docker compose build
```

Then deploy container:
```
docker compose up
```

## Endpoints:

- Api: http://localhost:8080
- Client: http://localhost:3000
- Elastic Search: http://localhost:9200
- Database: localhost,1433
