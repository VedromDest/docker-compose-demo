Container registry: https://hub.docker.com
account hebben
via website repo maken

::image publiceren via CLI (Kan ook via Docker Desktop UI)::

docker login

docker build -t stefanhogent/nt-aalst:backend .
% docker push stefanhogent/nt-aalst:backend

en zelfde voor front end

docker build -t stefanhogent/hogent-nt-demo:frontend .
% docker push stefanhogent/hogent-nt-demo:frontend