# Builder stage
FROM node:22 AS builder
WORKDIR /app
COPY ./package.json ./package-lock.json ./
RUN npm ci
COPY ./ ./

RUN npm run tsc
RUN npm run build

# Final stage
FROM caddy:2-alpine
COPY --from=builder /app/dist /usr/share/caddy
COPY Caddyfile /etc/caddy/Caddyfile
EXPOSE 443

