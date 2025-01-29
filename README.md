# Evaluacion_Tecnica_Sindy

# Instrucciones para probar la API en POSTMAN:
1. Crear cuenta (GET): http://localhost:44321/Cuenta/Crear
-Haz clic en el botón Send.
Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json

{
  "numeroCuenta": "123456789012",  // Un número de cuenta generado aleatoriamente
  "saldo": 1000
}
Esto te devolverá un objeto con el número de cuenta generado y el saldo inicial de 1000.
