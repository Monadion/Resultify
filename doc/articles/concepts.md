# Concepts

Resultify, C#’ta **Result pattern** yaklaşımıyla “başarı/başarısızlık” durumlarını *açıkça* modelleyen hafif ve akıcı (fluent) bir kütüphanedir. Amaç; kontrol akışı için exception kullanmayı azaltmak, hata yönetimini **tahmin edilebilir** ve **okunabilir** hale getirmektir.

> Temel fikir: Bir operasyon “ya başarılıdır ya da hatalıdır” ve bu durum tip seviyesinde temsil edilmelidir.

## Result nedir?

Resultify iki ana tip sunar:

- **`Result`**: Değer döndürmeyen ama başarı/başarısızlık durumunu taşıyan sonuç.
- **`Result<T>`**: Başarılıysa `T` değerini, başarısızsa hatayı taşıyan sonuç.

Bu iki tip, “işlem sonucu”nu tek bir dönüş tipinde standardize ederek, çağıran kodun her zaman aynı şekilde karar vermesini sağlar.

## Error nedir?

Başarısızlık durumunda sonuç, bir **`Error` record** ile temsil edilir. `Error` bir “neden” taşır ve `Match` gibi operasyonlar üzerinden çağıran kodun kontrollü şekilde hata yoluna girmesini sağlar.

## Fluent / Functional pipeline yaklaşımı

Resultify, operasyonları zincirleme kurmayı hedefler:

- **`Try(...)`**: Exception atabilecek bir işi güvenli şekilde çalıştırıp sonucu `Result`/`Result<T>` olarak paketler.
- **`Map(...)`**: Başarı durumunda değeri dönüştürür (success path).
- **`Bind(...)`**: Başarı durumunda bir sonraki adımı çalıştırır ve yine Result döndüren fonksiyonlarla zincir kurar (pipeline).
- **`Match(onSuccess, onFailure)`**: En sonda başarı/başarısızlık için ayrı davranış tanımlayıp “sonuçlandırır”.

Bu sayede kod, `try/catch` blokları ve dağınık kontrol ifadeleri yerine “akış” şeklinde okunur.

## Exception yaklaşımı

Resultify’ın hedefi, **kontrol akışı için exception kullanmamak**; exception üretme potansiyeli olan noktaları `Try` gibi kapılarla Result’a çevirmektir. Bu, hataların “yakalanıp unutulması” yerine, fonksiyon imzalarıyla açıkça taşınmasını teşvik eder.

## Ne zaman kullanmalı?

- Servis/metot zincirleri kuruyorsan (parse → validate → transform → persist gibi)
- “Hata olursa ne yapacağım?” kararını çağıran tarafta netleştirmek istiyorsan
- Exception’ların kontrol akışını gizlemesinden kaçınmak istiyorsan

## Ne zaman kullanmamalı?

- Tamamen throw/catch paradigmasına dayalı bir mimaride “her şeyi Result’a çevirmek” ek karmaşıklık getirebilir.
- Çok basit ve tek satırlık işlemlerde, Result zinciri gereksiz olabilir (takım standardına göre karar verin).