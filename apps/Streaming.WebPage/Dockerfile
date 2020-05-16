
FROM node:12-alpine

WORKDIR /home/www/

COPY package*.json ./

RUN npm install

RUN npm build

COPY ./public ./var/www

EXPOSE 5000

ENV HOST=0.0.0.0

CMD [ "npm", "start" ]