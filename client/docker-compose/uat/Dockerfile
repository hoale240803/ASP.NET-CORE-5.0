FROM node:14-alpine as build
WORKDIR /app

RUN npm install -g @angular/cli

COPY package.json .
RUN npm install
COPY . .
RUN npm run build:uat

FROM nginx as runtime
COPY --from=build /app/dist/uat /usr/share/nginx/html
COPY ["./compose/uat/default.conf","/etc/nginx/conf.d/default.conf"]
