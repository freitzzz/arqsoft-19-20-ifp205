# api-gateway-cdt

This folder contains a `node.js` project that represents the api-gateway. It is built using [`express-gateway`](https://www.express-gateway.io/) and requires the following environment variables to be set before deploying:

|Variable|Description|
|--------|-----------|
|`HOST`|Identifies the host in which the api-gateway is to listen the requests. On development mode should be set as `localhost`|
|`PORT`|Identifies the port in which the api-gateway will be available|