# Dot-net team 3 project - BetterBuys

## App Description

A simple app like amazon that sell variety of products - Razor

## Installation Instructions

1. Navigate to the directory you want to clone the project in and clone the project using: `git clone {project url}`.
2. Open the sln file that is cloned using visual studio.
3. Make a copy of appsettingsTEMPLATE.json and rename it to appsettings.json and fill in the required information.
    * This includes the local database server name in DefaultConnection's (localdb) and the database name according to what you like after the Database= up to the semicolon.
    * And the SiteKey and SecretKey for Recaptcha, fill in the key you retrieve from google recaptcha there so that the login works.
4. In Package Manager Console update the database using the following code:
    * `Update-Database -Context AuthDbContext`.
    * `Update-Database -Context StoreDbContext`.
    * Also as there might be an error in the nuget package run `dotnet restore` to restore the package.

## Requirements List

### Functional

-   Cart
-   Checkout
-   Shop - product page
-   Product Detail 

### Non-functional

-   Authentication - Register/Login

## Feature List - Nice to have

-   Search
-   Allow user to checkout as guest
-   Sort products by category
-   Product description page
-   Rating

## Prototypes

### Home Page

![Home Page](https://i.imgur.com/PEtOZY2.png)

### Product Page

![Product Page](https://i.imgur.com/urNqetV.png)

### Cart Page

![Cart Page](https://i.imgur.com/VQDiNvr.png)

### Checkout Page

![Checkout Page](https://i.imgur.com/RrEURm2.png)

### Product Detail Page

![Product Detail Page](https://i.imgur.com/9SjbVEl.png)
---

### ERD

Tables: Product, Category, ProductCategory, Cart, CartProduct, User
![ERD](https://i.imgur.com/muO5OJG.png)
