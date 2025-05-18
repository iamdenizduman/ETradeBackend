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
