# Makefile for managing the lifecycle of the project using Docker Compose

.PHONY: build test deploy clean

# Default build environment
BUILD_ENV ?= dev

# Build the project
build:
	docker-compose -f docker-compose.yml   build

# Run tests
test:
	docker-compose -f docker-compose.yml -f docker-compose.test_.yml build
	docker-compose -f docker-compose.yml -f docker-compose.test_.yml up --abort-on-container-exit

run:
	docker-compose -f docker-compose.yml up   
# Deploy the project (use BUILD_ENV=prod for production)
deploy:
	docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d

# Clean up resources
clean:
	docker-compose -f docker-compose.yml -f docker-compose.prod.yml down

# Pull the latest images