# dotnet-core-jwt-authentication example

---

An implementation of JWT Authentication/Authorization using .NET Core 3.

### Paths

| PATH | METHOD | DESCRIPTION |
|------|--------|-------------|
| /auth/register | `POST` | Registers new user |
| /auth/tokens | `POST` | Authenticates and returns tokens |
| /auth/refresh | `POST` | Refreshes a access token with a refresh token |
