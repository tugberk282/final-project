# Final Project

Bu depo, Unity ile geliştirilmekte olan bitirme oyunu projesini içerir. Proje henüz başlangıç ve prototipleme aşamasındadır; kapsamı geliştirme sürecinde genişleyecektir.

## Mevcut prototip

- Basit bir 3B karakter ve test zemini
- Taşınabilir gerçek zamanlı Point Light
- Işık hareketine göre yönü ve uzunluğu değişen dinamik gölge
- Test kamerası ve dolgu ışığı
- AI destekli Unity geliştirme için MCP for Unity entegrasyonu

Bu sahne oyunun nihai yapısını temsil etmez; mekanik ve görsel denemeler için hazırlanan ilk prototiptir.

## Gereksinimler

- Unity `6000.2.15f1` veya uyumlu Unity 6 sürümü
- Git
- MCP özelliklerini kullanmak isteyenler için Python 3.10+ ve `uv`

## Çalıştırma

1. Repoyu klonlayın.
2. Unity Hub üzerinden **Add project from disk** seçeneğiyle klasörü ekleyin.
3. Projeyi Unity ile açın ve paketlerin indirilmesini bekleyin.
4. İlk prototipi görmek için `Assets/Scenes/ShadowDemo.unity` sahnesini açın.
5. Hierarchy içinden `Move_Me_PointLight` nesnesini seçip taşıyın.

Işığın karaktere göre konumu değiştikçe gölge gerçek zamanlı olarak yön ve uzunluk değiştirir.

## MCP for Unity

Proje, `MCP for Unity v10.3.0` paketini kullanır. Paket `Packages/manifest.json` içinde sabitlenmiştir. MCP kullanmak zorunlu değildir; sahne normal bir Unity projesi olarak çalışır.

