## 📘 Dokümantasyon - ETradeBackend

### 🔐 AuthService.API

#### 1. Login - Kullanıcı Giriş Servisi

Kullanıcının sisteme giriş yaparak token aldığı servistir.

- **Request (POST /api/auth/login):**

```json
{
  "email": "example@gmail.com",
  "password": "******"
}
```

- **Response:**

```json
{
  "accessToken": {
    "token": "******",
    "expiration": "2025-05-18T01:45:41.9508044+03:00"
  },
  "isSuccess": true,
  "text": "Giriş Başarılı"
}
```

---

#### 2. Register - Kullanıcı Kayıt Servisi

Kullanıcının sisteme kayıt olmasını sağlayan servistir.

- **Request (POST /api/auth/register):**

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@gmail.com",
  "password": "******"
}
```

- **Response:**

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@gmail.com",
  "role": "User"
}
```

---

### 📦 CatalogService.API

#### 3. AddCategory - Kategori Kayıt Servisi

Kategorilerin eklendiği servistir.

- **Request (POST /api/Categories/AddCategory):**

```json
{
  "name": "Süpürge"
}
```

- **Response:**

```json
{
  "name": "Süpürge",
  "isSuccess": true,
  "text": "Kategori başarıyla eklendi."
}
```

#### 4. GetAllCategories - Kategori Listeleme Servisi

Kategorilerin listelendiği servistir.

- **Request (GET /api/Categories/GetAllCategories):**

- **Response:**

```json
{
  "categories": [
    {
      "id": "8a6684e5-609c-4b2a-89c6-2b82e5ca5f38",
      "name": "Televizyon"
    },
    {
      "id": "e0007b07-ec1f-4f16-8b1d-90760e3aa9ce",
      "name": "Bilgisayar"
    },
    {
      "id": "a348f2aa-3183-4c97-9577-4c78f3c07116",
      "name": "Beyaz Eşya"
    }
  ],
  "isSuccess": true,
  "text": "Kategoriler başarıyla getirildi"
}
```

#### 5. GetCategory - Kategori Getirme Servisi

Kategorinin getirdiği servistir.

- **Request (GET /api/Categories/GetCategory/8a6684e5-609c-4b2a-89c6-2b82e5ca5f38):**

- **Response:**

```json
{
  "category": {
    "id": "8a6684e5-609c-4b2a-89c6-2b82e5ca5f38",
    "name": "Televizyon"
  },
  "isSuccess": true,
  "text": "Kategori başarıyla getirildi"
}
```

#### 6. AddProduct - Ürün Kayıt Servisi

Ürünlerin eklendiği servistir.

- **Request (POST /api/Products/AddProduct):**

```json
{
  "name": "Kablosuz Bluetooth Kulaklık",
  "description": "Gürültü engelleme özelliğine sahip, 20 saat pil ömrü sunan, yüksek kaliteli kulak üstü kablosuz kulaklık.",
  "price": {
    "amount": 149.99,
    "currency": "TRY"
  },
  "imageUrl": "wireless-headphones.jpg",
  "categoryId": "8a6684e5-609c-4b2a-89c6-2b82e5ca5f38"
}
```

- **Response:**

```json
{
  "name": "Kablosuz Bluetooth Kulaklık",
  "isSuccess": true,
  "text": "Ürün başarıyla eklendi."
}
```
