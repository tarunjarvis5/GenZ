# GenZ
---
This application allows users to deploy apps quickly within few seconds, allowing users to create their own custom URL


### Installation
---
[Docker](https://www.docker.com/products/docker-desktop/) to install Docker.

[Git](https://git-scm.com/downloads) to install Git.


### Commands
---
* > To create a docker network and have the containers deployed to it
```
> docker network create local-nginx-rproxy
```
* > To register the url "localhost:8081"
```
> netsh http add urlacl url=http://+:8081/ user="Everyone"
```
* > To run the nginx reverse proxy in a container and listen to port 80:80

**Note : Navigate to "./NginxProxy" directory**
```
> docker-compose up -d
```

### Project setup
---
**Navigate to ./WebServer/Deploy/Constants**

change the directory path to the store the code and docker-compose file
```cs
public static string AppDockerComposeFolder = "C:\\location\\AppDockerComposeFolder";
public static string AppCodeFolder = "C:\\location\\AppCodeFolder";
```

### Run
---
Run the **"GenZServer"** project

Run the **"GenZPlatformApp.Server"** project

# Summary
***

