# Evaluacion_Tecnica_Sindy

# Instrucciones para probar la API en POSTMAN:
1. Crear cuenta (GET): https://localhost:44321/Cuenta/Crear
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
----------------------------------------------------------------------------------------------
2. Consultar saldo (GET): https://localhost:44321/Cuenta/{numeroCuenta}

Reemplaza {numeroCuenta} con el número de cuenta que obtuviste en la respuesta anterior. Por ejemplo, si tu número de cuenta es 123456789012, la URL sería:

Ejemplo: https://localhost:5000/Cuenta/123456789012

Haz clic en el botón Send.

Respuesta esperada:

Código de estado HTTP: 200 OK
Cuerpo de la respuesta:
json

"1000"
Esto te devolverá el saldo actual de la cuenta.
