# Builder stage
FROM node:22 AS builder
WORKDIR /app
COPY ./package.json ./package-lock.json ./
RUN npm ci
COPY ./ ./
RUN npm run tsc
RUN npm run build

# Runner stage
FROM nginx:stable-alpine
COPY --from=builder /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

