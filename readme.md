# Docker Compose Voorbeeld

Dit is een piepklein voorbeeld van hoe je een compositie kan maken van 
  - mysql db (image)
  - .net api (build)
  - react app (build)

> [!TIP]
> Services in een compositie worden standaard samen in een virtueel netwerk geplaatst. Hierin kunnen ze mekaar bereiken op de **interne** poorten. De UI web app wordt geserved vanuit Docker, maar runt in jouw browser op localhost. Dit heeft implicaties voor api endpoint urls en CORS configuratie.

## Lokaal

`DockerComposeLocal` is een compositie die werkt met eigen source code
  - mysql db (image)
  - .net api (build from source)
  - react app (build from source)

## Publiceren

### Dockerhub

Container registry: [https://hub.docker.com]
- Maak een account
- Maak een repo

### image publiceren via CLI (Kan ook via Docker Desktop UI)

Log in
````
docker login
````

Build lokaal de image. Gebruik (uiteraard) de naam van jouw account/repo:tag
````
docker build -t stefanhogent/nt-aalst:backend .
````

Push de gebouwde image naar docker hub. Gebruik (uiteraard) de naam van jouw account/repo:tag
````
docker push stefanhogent/nt-aalst:backend
````

en zelfde voor front end

## Compose Uit Images

`DockerComposePublish` is een versie van dezelfde software, maar die enkel met gepublishte images werkt. Dit is handiger om software te distribueren.

## Verbeteringen

Dit voorbeeld gebruikt environment variables voor db en backend. De front end heeft hardcoded urls. Dit is onwenselijk.
Studenten kunnen de lector Web 3 consoluteren voor info over vite environment.
