# Architecture

Bu sayfa, Resultify reposunun “hangi parça nerede?” sorusunu cevaplar ve katkı verecek kişiler için hızlı bir yönlendirme sağlar.

## High-level görünüm

Repo, tek bir çekirdek kütüphane etrafında organize edilir:

- **Core Library**: Resultify’nin asıl `Result` / `Result<T>` ve operasyonlarının bulunduğu paket.
- **Tests**: Çekirdek davranışın doğrulandığı unit test’ler.
- **Samples**: Kütüphanenin kullanımını gösteren örnek proje.
- **Docs**: DocFX tabanlı dokümantasyon ve GitHub Pages yayınlama altyapısı.

## Repo yapısı

Kök dizinde öne çıkan klasörler:

- `src/Resultify/`  
  Çekirdek kütüphane kodu (paket buradan üretilir).
- `test/Resultify.UnitTest/`  
  Unit test projesi.
- `samples/Resultify.Sample/`  
  Kullanım örnekleri.
- `doc/`  
  DocFX dokümantasyon kaynakları (GitHub Pages’e yayınlanır).
- `references/`, `reports/`  
  Referans / raporlama amaçlı yardımcı içerikler (projeye özel).

Kök dosyalardan bazıları:

- `CHANGELOG.md` (sürüm değişiklikleri)
- `Directory.Build.props`, `Directory.Packages.props` (çözüm genelinde build/paket standardı)
- `Resultify.slnx` (solution)
- `global.json` (SDK/Tooling pinleme amacıyla kullanılabilir)
- `.editorconfig` (kod stili)

## Paket sınırları ve bağımlılık yaklaşımı

Resultify, “küçük çekirdek” yaklaşımını hedefler: Result tipi + birkaç temel operasyonla (Try/Map/Bind/Match) işlevsellik sağlar. Bu, bağımlılıkları ve yüzey alanını küçük tutarak hem öğrenmeyi hem de bakım maliyetini azaltır.

> Tasarım hedefi: Kullanım tarafında minimum sürtünme, çekirdekte net ve test edilebilir davranış.

## Dokümantasyon mimarisi (DocFX + GitHub Pages)

Dokümantasyon `doc/` altında tutulur ve GitHub Actions üzerinden GitHub Pages’e yayınlanır.
Changelog’da ayrıca `docs.yml` workflow’unun eklendiği ve build adımında bazı düzenlemeler yapıldığı belirtilir.

Önerilen pratik:
- `CHANGELOG.md` root’ta kalsın (GitHub’ın bulması ve release akışı için ideal).
- DocFX menüsünde “Changelog” sayfası olarak linkle veya build sırasında dokümanlara dahil et.

## Test stratejisi

Kritik davranışlar unit test’lerle doğrulanır (changelog’da test sınıflarından bahsedilir).
Bu repo için ideal test kapsamı:
- `Try` exception sarımı
- `Map` ve `Bind`’in sadece success path’te çalışması
- `Match`’in doğru kola girmesi
- `Result` ve `Result<T>` arasındaki temel davranış farkları