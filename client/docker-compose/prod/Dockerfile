FROM node:14-alpine as build
WORKDIR /app

RUN npm install -g @angular/cli

COPY package.json .
RUN npm install
COPY . .
RUN npm run build:prod

FROM nginx as runtime
COPY --from=build /app/dist/prod /usr/share/nginx/html
COPY ["./compose/prod/default.conf","/etc/nginx/conf.d/default.conf"]
