# Base Node.js stage for installing dependencies and running builds/tests
FROM  node:22.3.0-alpine3.19 AS node-base
WORKDIR /app/frontend
COPY package*.json ./
RUN npm install

# Build stage: Build the application
FROM node-base AS builder
COPY . .
RUN npm run build

# Cucumber stage: Install Selenium and run Cucumber tests
FROM node-base AS test
COPY . .
RUN npm run test-cucumber
RUN npm run test-jest

# Production stage: Prepare production image with Nginx
FROM nginx:stable-alpine AS production
COPY --from=builder /app/frontend/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]