# Docker Compose Voorbeeld

Dit is een piepklein voorbeeld van hoe je een compositie kan maken van 
  - mysql db (image)
  - .net api (build)
  - react app (build)

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
% docker push stefanhogent/nt-aalst:backend
````

en zelfde voor front end

## Compose Uit Images

`DockerComposePublish` is een versie van dezelfde software, maar die enkel met gepublishte images werkt. Dit is handiger om software te distribueren.
