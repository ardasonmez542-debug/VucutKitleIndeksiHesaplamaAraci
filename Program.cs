var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Frontend (HTML, CSS ve Form Yapısı) fonksiyonu
string GetHtmlContent(string resultBlock = "")
{
    return $@"
    <!DOCTYPE html>
    <html lang='tr'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Vücut Kitle İndeksi Hesaplama</title>
        <style>
            body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f4f7f6; margin: 0; display: flex; justify-content: center; align-items: center; height: 100vh; }}
            .container {{ background: white; padding: 30px; border-radius: 12px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); width: 100%; max-width: 400px; }}
            h2 {{ text-align: center; color: #333; margin-bottom: 20px; }}
            .form-group {{ margin-bottom: 15px; }}
            label {{ display: block; margin-bottom: 5px; color: #666; font-weight: bold; }}
            input {{ width: 100%; padding: 10px; border: 1px solid #ddd; border-radius: 6px; box-sizing: border-box; font-size: 16px; }}
            button {{ width: 100%; padding: 12px; background-color: #2ecc71; color: white; border: none; border-radius: 6px; font-size: 16px; font-weight: bold; cursor: pointer; transition: background 0.3s; margin-top: 10px; }}
            button:hover {{ background-color: #27ae60; }}
            .result {{ margin-top: 20px; padding: 15px; border-radius: 6px; text-align: center; font-size: 18px; font-weight: bold; }}
            .info {{ background-color: #e8f8f5; color: #117a65; border-left: 5px solid #2ecc71; }}
            .error {{ background-color: #fadbd8; color: #78281f; border-left: 5px solid #e74c3c; }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h2>VKİ Hesaplayıcı</h2>
            <form method='POST' action='/'>
                <div class='form-group'>
                    <label for='height'>Boyunuz (cm):</label>
                    <input type='number' id='height' name='height' placeholder='Örn: 175' required min='50' max='250'>
                </div>
                <div class='form-group'>
                    <label for='weight'>Kilonuz (kg):</label>
                    <input type='number' id='weight' name='weight' placeholder='Örn: 70' required min='1' max='300' step='0.1'>
                </div>
                <button type='submit'>Hesapla</button>
            </form>
            {resultBlock}
        </div>
    </body>
    </html>";
}

// 1. HTTP GET İsteği: Sayfa ilk açıldığında boş formu gösterir
app.MapGet("/", () => {
    return Results.Content(GetHtmlContent(), "text/html; charset=utf-8");
});

// 2. HTTP POST İsteği: Form gönderildiğinde (Backend hesaplama) burası çalışır
app.MapPost("/", async (HttpContext context) => {
    var form = await context.Request.ReadFormAsync();
    
    // Formdan gelen verileri yakalama ve doğrulama
    if (double.TryParse(form["height"], out double heightCm) && double.TryParse(form["weight"], out double weight))
    {
        // VKI Formülü: Kilo / (Boy(m) * Boy(m))
        double heightMeter = heightCm / 100;
        double bmi = weight / (heightMeter * heightMeter);
        
        // Sonuç durumunu belirleme
        string category = bmi switch
        {
            < 18.5 => "Zayıf 🦴",
            < 25 => "Normal Kilolu 💪",
            < 30 => "Fazla Kilolu 🍕",
            _ => "Obez ⚠️"
        };

        // UI'a basılacak sonuç componenti
        string successHtml = $@"
            <div class='result info'>
                VKİ Skorunuz: {bmi:F1}<br>
                Durum: {category}
            </div>";

        return Results.Content(GetHtmlContent(successHtml), "text/html; charset=utf-8");
    }

    string errorHtml = "<div class='result error'>Lütfen geçerli değerler girin!</div>";
    return Results.Content(GetHtmlContent(errorHtml), "text/html; charset=utf-8");
});

app.Run();