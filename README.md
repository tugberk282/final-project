# FinalProject — Unity Işık ve Gölge Simülasyonu

Bu proje, gerçek zamanlı ışık konumuna bağlı olarak bir karakterin zemindeki gölgesinin yönünü ve uzunluğunu gösteren Unity bitirme projesidir.

## Özellikler

- Parçalardan oluşturulmuş örnek 3B karakter
- Gölge alan geniş zemin
- Taşınabilir gerçek zamanlı Point Light
- Işık hareket ettikçe değişen yumuşak gölge
- Hazır kamera ve dolgu ışığı
- AI destekli Unity geliştirme için MCP for Unity entegrasyonu

## Gereksinimler

- Unity `6000.2.15f1` veya uyumlu Unity 6 sürümü
- Git
- MCP özelliklerini kullanmak isteyenler için Python 3.10+ ve `uv`

## Çalıştırma

1. Repoyu klonlayın.
2. Unity Hub üzerinden **Add project from disk** seçeneğiyle klasörü ekleyin.
3. Projeyi Unity ile açın ve paketlerin indirilmesini bekleyin.
4. `Assets/Scenes/ShadowDemo.unity` sahnesini açın.
5. Hierarchy içinden `Move_Me_PointLight` nesnesini seçip taşıyın.

Işığın karaktere göre konumu değiştikçe gölge gerçek zamanlı olarak yön ve uzunluk değiştirir.

## MCP for Unity

Proje, `MCP for Unity v10.3.0` paketini kullanır. Paket `Packages/manifest.json` içinde sabitlenmiştir. MCP kullanmak zorunlu değildir; sahne normal bir Unity projesi olarak çalışır.

