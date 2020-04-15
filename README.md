# Stream2U

La aplicacion es un servicio de streaming que tiene como objetivo permitirle a las personas stremear desde su pc y transmitirlo a las personas que quieran ver su stream, adicionalmente ofrecele una calidad cual le convenga a la persona para ver el stream de la otra persona.

Opcionalmente que las personas puedan comentar sobre el contenido en tiempo real.

## Solucion

La estructura de la aplicacion consiste varios elementos, un punto donde se recibe la transmision, un punto donde se guarda la transmision y otro donde se transmite el video, adicionalmente, las transmisiones deben ser procesadas en distintas calidades inferiores a la de la transmision original.

## Imagenes

- Imagen de encoder
- Imagen para el programa para manejar el stream
- Imagen para el servicio de transmision a puntos de video
- Imagen de base de datos

## Elementos de infrastructura opcionales

- DRM (Si se quiere establecer requerimientos de proteccion de stream)
- CDN para velocidad de dar el servicio
- Servidor de chat en tiempo real

## Arquitectura

![Arquitectura][imagen-arc]
<hr>
La arqutectura esta formada por 3 partes:

- Aplicaciones
- Canales
- Clientes

Las aplicacion de manejo es aquella que maneja los streams,y maneja de que esten estructurados, asociados, etc. La otra aplicacion, el endpoint de stream sirve para que se conecten los clientes de una region y puedan acceder a los canales de las personas o de ellos mismos

Los canales son puntos de encoding y distribucion de manejo que se encarga de crear los streams, los guarda como videos y por ende existen como un elemento mas en el sistema, es la interaccion de un encoder con un app de manejo central.

## Elementos de software

- NGINX
- Base de datos de usuarios (MariaDB)
- Servicio de Transmisicion (Asp.Net)
- Servicio de Encoding (.Net worker  + ffmpeg)
- Endpoint de streaming (Asp.Net)
- UFW
- Aplicacion Mobil (Nativescript)
- Aplicacion Web (SvelteJS)
- (Opcional) Servidor de chat (Asp.Net)

## Descripcion de elementos de software

### NGINX

Servidor que nos permitira tener la aplicacion (servidor inverso)

### Base de datos de usuario

La base de datos de usuario nos servira para que podamos ver quienes son los usuarios que pueden ver y usuarios que puedan transmitir

### Servicio de transmisicion

Este servicio permitira manejar el stream, ver que este autenticado, entre otras cosas, manejara todo la parte logica del programa y el proceso

### Servicio de encoding

Se utilizara ffmpeg para hacer que las transmisiones que sean validas sean convertidas en diferentes formatos y tamaños para su facil distribucion

### Endpoint de streaming

Manejara todas las request de ver el video, adicionalmente de permitir manejar a los usuarios con la base de datos (autenticar y autorizar usuarios), Dicho de otra manera es la logica de las aplicaciones mobiles y webs

### UFW

El UWF estara configurado para no permitir en la maquina que tiene las imagenes no caiga en manos equivocadas, realmente solo permitiendo la comunicacion interna de ellos para que se puedan enviar las aplicaciones mensajes entre ellos, entre otras cosas, externamente, nadie debe poder acceder a las maquinas de canales, solamente consumir su API y ya esta

### Aplicacion mobil y web

Aplicaciones que deben consumir la API de los streaming endpoints para funcionar, hechos en svelte para mayor reuso de codigo

### Servidor de chat

Esto es un elemento opcional pero se podria agregar un servicio extra para mantener las conversaciones del chat y mantener a tiempo real el chat sobre un video/stream.

## Licencia

En el archivo de LICENSE se encuentra, pero en resumen, es MIT

[imagen-arc]: https://github.com/Deecellar/Stream2U/raw/master/docAssets/Arq-Streaming.png "Imagen de la arquitectura"
