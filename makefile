.PHONY: build-backend build-frontend run-backend run-frontend stop-backend stop-frontend test-backend test-frontend

build-backend:
    docker-compose build backend

build-frontend:
    docker-compose build frontend

run-backend:
    docker-compose up -d backend

run-frontend:
    docker-compose up -d frontend

stop-backend:
    docker-compose stop backend

stop-frontend:
    docker-compose stop frontend

test-backend:
    docker-compose run --rm backend dotnet test

test-frontend:
    docker-compose run --rm frontend npm test