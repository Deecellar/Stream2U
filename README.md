# Stream2U
La aplicacion es un servicio de streaming que tiene como objetivo permitirle a las personas stremear desde su pc y transmitirlo a las personas que sean necesarias

# Introduccion
La estructura de la aplicacion necesita varios elementos,  un punto donde se recibe la transmision, un punto donde se guarda la transmision y otro donde se transmite el video, adicionalmente, las transmisiones deben ser procesadas en distintas calidades inferiores a la de la transmision original.

# Imagenes
- Imagen de encoder
- Imagen para el programa para manejar el stream
- Imagen para el servicio de transmision a puntos de video
- Imagen de base de datos

# Elementos de infrastructura opcionales
- DRM (Si se quiere establecer requerimientos de proteccion de stream)
- CDN para velocidad de dar el servicio

# Arquitectura
![Arquitectura][imagen-arc]
La arqutectura esta formada por 3 partes
- Aplicaciones
- Canales
- Clientes

Las aplicacion de manejo es aquella que maneja los streams,y maneja de que esten estructurados, asociados, etc. La otra aplicacion, el endpoint de stream sirve para que se conecten los clientes de una region y puedan acceder a los canales de las personas o de ellos mismos

Los canales son puntos de encoding y distribucion de manejo que se encarga de crear los streams, los guarda como videos y por ende existen como un elemento mas en el sistema, es la interaccion de un encoder con un app de manejo central.


## Elementos de software 
- NGINX
- MariaDB
- Servicio de Transmisicion
- Servicio de Encoding
- Servicio de guardado
- Servicio de uso de la app (lo que ven las personas)

[imagen-arc]: https://github.com/Deecellar/Stream2U/raw/master/docAssets/Arq-Streaming.png "Imagen de la arquitectura"