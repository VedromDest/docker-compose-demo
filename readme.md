# Opname

Er bestaat een [HOGENT opname](https://hogent-my.sharepoint.com/:v:/g/personal/stefan_courteaux_hogent_be/IQChLh0JEbr1Ra_jNQMvitpZAdt_MY-noXtMDzHuscMH1es?e=sIlvYr&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJTdHJlYW1XZWJBcHAiLCJyZWZlcnJhbFZpZXciOiJTaGFyZURpYWxvZy1MaW5rIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXcifX0%3D).

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

Container registry: [hub.docker.com](https://hub.docker.com)
- Maak een account
- Maak een repo

### image publiceren via CLI (Kan ook via Docker Desktop UI)

Log in
````
docker login
````

Build lokaal de image. Gebruik (uiteraard) de naam van jouw account/repo:tag
````
docker build -t stefanhogent/hogent-docker-demo:backend .
````

Push de gebouwde image naar docker hub. Gebruik (uiteraard) de naam van jouw account/repo:tag
````
docker push stefanhogent/hogent-docker-demo:backend
````

> [!TIP]
> Je herhaalt deze operaties voor elke image die je beoogt te publiceren.

#### Cross-builden

Indien je wil cross-builden naar andere architecturen, is dat mogelijk. 
````
docker buildx build --platform linux/amd64,linux/arm64 -t stefanhogent/hogent-docker-demo:backend .
````
Waarom zou je dat willen?
- Vanop standaard X86 laptop images builden die compatibel zijn met Apple M computers, Snapdragon Windows computers en energiezuinige ARM datacenter servers.
- Vanop (AR)M computers builden voor standaard X86 laptops en conventionele datacenter servers.

Waarom altijd linux? Grofweg: omdat Docker standaard alles runt in een Linux VM, ook op windows en macos.

## Compose Uit Images

`DockerComposePublish` is een versie van dezelfde software, maar die enkel met gepublishte images werkt. Dit is handiger om software te distribueren.

## Verbeteringen

Dit voorbeeld gebruikt environment variables voor db en backend. De front end heeft hardcoded urls. Dit is onwenselijk.
Studenten kunnen de lector Web 3 consoluteren voor info over vite environment.

## Troubleshooting

Wanneer je de structuur van dit werkend voorbeeld overbrengt op je eigen applicatie, zal dit zelden van de eerste keer correct zijn. 

Typische problemen:
- .env settings
- poorten
- urls
- CORS
- verkeerde verwachtingen van react-router
- ...
