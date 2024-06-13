# Выполнение тестового задания
## Задача:
Реализовать сервис с JSON - сервис для предоставления информации о списке товаров, а также возможностью заказа/удаления товара и заказа.

В качестве БД можно использовать статический объект в контроллере asp.net или любую известную вам реляционную СУБД

В качестве клиента - любой инструмент для отправки и получения запросов. Ex: Insomnia или Restlet плагин для Хрома

Как минимум, должны быть реализованы сущности "Товар" и "Заказ", и методы работы с этими сущностями: добавление нового товара в список, удаление существующего товара, просмотр списка существующих товаров, создание заказа на товар (или товары - тут реализация на усмотрение кандидата), удаление заказа, просмотр списка заказов.

# Инструкция

ProductOrderService - это простое приложение на базе ASP.NET Core, предоставляющее API для управления товарами и заказами.

## Установка

1. Клонируйте репозиторий:
   
  ```bash
  git clone https://github.com/ваш-пользователь/product-order-service.git
  ```

2. Перейдите в директорию проекта:

  ```bash
  cd product-order-service
  ```

3. Установите зависимости и запустите проект:

  ```bash
  dotnet restore
  dotnet run
  ```
# Использование API
## Базовый URL
API доступен по адресу:

* HTTP: http://localhost:5000
* HTTPS: https://localhost:5001

## Товары (Products)
### Получение списка товаров (GET)
* Метод: GET
* URL: `/api/products`
#### Пример запроса:

```bash
curl -X GET "http://localhost:5000/api/products"
```

#### Пример ответа:

```json
[
    {
        "id": 1,
        "name": "Product 1",
        "price": 10.0
    },
    {
        "id": 2,
        "name": "Product 2",
        "price": 20.0
    }
]
```

### Добавление нового товара (POST)
* Метод: POST
* URL: `/api/products`
* Тело запроса:
```json
{
    "name": "New Product",
    "price": 25.0
}
```

#### Пример запроса:

```bash
curl -X POST "http://localhost:5000/api/products" -H "Content-Type: application/json" -d '{
    "name": "New Product",
    "price": 25.0
}'
```
#### Пример ответа:

```json
{
    "id": 3,
    "name": "New Product",
    "price": 25.0
}
```
### Удаление товара (DELETE)
* Метод: DELETE
* URL: /api/products/{id}
#### Пример запроса:

```bash
curl -X DELETE "http://localhost:5000/api/products/1"
```
#### Пример ответа:

```json
{
    "id": 1,
    "name": "Product 1",
    "price": 10.0
}
```
## Заказы (Orders)
### Получение списка заказов (GET)
* Метод: GET
* URL: /api/orders
#### Пример запроса:

```bash
curl -X GET "http://localhost:5000/api/orders"
```
#### Пример ответа:

```json
[
    {
        "id": 1,
        "products": [
            { "id": 1, "name": "Product 1", "price": 10.0 }
        ]
    },
    {
        "id": 2,
        "products": [
            { "id": 2, "name": "Product 2", "price": 20.0 }
        ]
    }
]
```
### Создание нового заказа (POST)
* Метод: POST
* URL: /api/orders
* Тело запроса:
```json
{
    "products": [
        { "id": 1, "name": "Product 1", "price": 10.0 }
    ]
}
```
#### Пример запроса:

```bash
curl -X POST "http://localhost:5000/api/orders" -H "Content-Type: application/json" -d '{
    "products": [
        { "id": 1, "name": "Product 1", "price": 10.0 }
    ]
}'
```
#### Пример ответа:

```json
{
    "id": 3,
    "products": [
        { "id": 1, "name": "Product 1", "price": 10.0 }
    ]
}
```
### Удаление заказа (DELETE)
* Метод: DELETE
* URL: /api/orders/{id}
#### Пример запроса:

```bash
curl -X DELETE "http://localhost:5000/api/orders/1"
```
#### Пример ответа:

```json
{
    "id": 1,
    "products": [
        { "id": 1, "name": "Product 1", "price": 10.0 }
    ]
}
```
## Swagger UI
Вы также можете использовать Swagger UI для интерактивного тестирования API. Swagger UI доступен по адресу:

* HTTP: http://localhost:5000/swagger
* HTTPS: https://localhost:5001/swagger
