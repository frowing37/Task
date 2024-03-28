                                                                          
                                                                                                          - TASK -

 Proje;
 - MacOS işletim sistemine sahip bir bilgisayarda,
 - JetBrains Rider idesinde, 
 - .Net Core 7.0 kullanılarak yazılmıştır.
 - Veritabanı olarak Azure SQL Server kullanılmıştır.
 - ORM aracı olarak EntityFramework araçları kullanılmıştır.

 Projede, Layered Architecture ve Repository Design Pattern kullanılmaktadır. 4 katman, 5 farklı proje klasöründen oluşmaktadır. Bunlar;

 - Entity Layer : Proje dosyası Class Library olarak açılmıştır. Projede kullanılacak entity'lere erişilen katmandır. Concrete klasörü altında Order sınıfı ve parametre olarak aldığı OrderStatus sınıfı bulunmaktadır.

 - DataAccess Layer : Proje dosyası Class Library olarak açılmıştır. Projedeki veritabanı bağlantısının yapıldığı katmandır. Concrete klasörü altında veritabanı bağlantısını içeren Context sınıfı vardır. Abstract klasörü içerisinde Generic yapının interface'i ve sınıflara özgü interface'ler vardır. Repository klasörünün altında Generic interface'i implement edilmektedir. EntityFramework klasöründe entity'lere özgü sınıfların interface'leri ve generic repository implement edilmektedir.

 - BusinessLogic Layer : Proje dosyası Class Library olarak açılmıştır. Proje servislerinin bulunduğu katmandır. Abstract klasöründe generic bir interface ve entity'lere özgü servis interface'ler bulunmaktadır. Concrete klasörü altında servis interface'leri manager sınıflara implement edilir ve DataAccess katmanındaki interface'ler dependency injection ile bağımlılıkları azaltır, koda esneklik katar.

 - Api Katmanı : Mikroservis mimarisine uygun olması için metodlar en küçük yapılara ayrılmaktadır. Bu yüzden metodlar için iki ayri Web API projesi açılmıştır.
                 * OrderSearcher 
                   / Body olarak verilen filtreye göre filtreleme işlemi yapıp sonucu olan Order'ları geri dönen metodu içeren API.
                   / BusinessLogic katmanındaki servisler dependency injection ile implement edilir.


                 * OrderSaver 
                   / Gerekli validasyonlar sonucu post edilen Order'ları veritabanına ekleyen API.
                   / BusinessLogic katmanındaki servisler dependency injection ile implement edilir.

