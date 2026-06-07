# Vücut Kitle İndeksi (VKİ) Hesaplayıcı

Bu proje, Macbook (macOS) ortamında **VS Code** kullanılarak geliştirilmiş, **C# (.NET Minimal API)** ve **HTML/CSS** teknolojilerini tek bir dosyada (`Program.cs`) birleştiren hafif ve modern bir web tabanlı form uygulamasıdır.

## 🚀 Proje Amacı
Geleneksel web uygulamalarında frontend ve backend mimarileri ayrı klasörlerde ve dosyalarda tutulur. Bu proje, .NET 6+ ile hayatımıza giren **Minimal API** yaklaşımını kullanarak, küçük ölçekli form tabanlı uygulamaların ne kadar yalın, hızlı ve tek bir kod dosyası üzerinden yönetilebileceğini göstermek amacıyla geliştirilmiştir.

## 🛠️ Gereksinimler
Uygulamayı yerel makinenizde çalıştırmak için aşağıdaki araçların yüklü olması gerekmektedir:
* **macOS** (Macbook) veya uyumlu bir işletim sistemi
* **.NET 8.0 SDK** (veya üzeri)
* **Visual Studio Code (VS Code)**
    * *C# Dev Kit* eklentisi (tavsiye edilir)

## 📦 Kurulum ve Çalıştırma

1.  **Depoyu Klonlayın veya Kodları İndirin:**
    Proje klasörünü bilgisayarınıza indirin.
    ```bash
    cd VkiHesaplayici
    ```

2.  **Projeyi Çalıştırın:**
    Terminal üzerinden projeyi "hot reload" (canlı yenileme) modunda başlatmak için şu komutu çalıştırın:
    ```bash
    dotnet watch
    ```

3.  **Tarayıcıda Görüntüleyin:**
    Uygulama başarıyla ayağa kalktığında terminalde belirtilen adrese (genellikle `http://localhost:5200` veya benzeri) tarayıcınız üzerinden gidin.

## 🖥️ Uygulama Yapısı
Proje, tek bir `Program.cs` dosyasından oluşur:
* **GET `/` İsteği:** Kullanıcıya HTML/CSS arayüzünü ve giriş formunu sunar.
* **POST `/` İsteği:** Formdan gelen Boy (cm) ve Kilo (kg) verilerini işler, VKİ formülüne göre hesabı yapar ve sonucu aynı dinamik arayüz üzerinden kullanıcıya geri döndürür.

## 🧠 VKİ Hesaplama Mantığı
Uygulama arka planda şu matematiksel formülü işletmektedir:
$$\text{VKİ} = \frac{\text{Kilo (kg)}}{\left(\frac{\text{Boy (cm)}}{100}\right)^2}$$

* **< 18.5:** Zayıf 🦴
* **18.5 - 24.9:** Normal Kilolu 💪
* **25.0 - 29.9:** Fazla Kilolu 🍕
* **>= 30.0:** Obez ⚠️

<img width="1490" height="754" alt="Uyguluma_Ekranı" src="https://github.com/user-attachments/assets/05578aa5-b002-4771-844d-3fd3414d84ea" />

