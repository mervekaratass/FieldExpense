# Saha Masraf Yönetimi📝
<p> 📌Bu proje Patika.dev ile gerçekleştirilen Papara Kadın Yazılımcı Bootcamp eğitiminin final case ödevi için geliştirdiğim projedir. </p>
<p> 📌 Projenin çalışır halinin ekran görüntülerine ait dosyasına <a href="https://drive.google.com/file/d/1Q7mqndQn31VuwIUrZkpJCXzhyQg1p4Sj/view"> buradan </a> ulaşabilirsiniz. </p>


#### GEREKSİNİMLER 🛠
- ✅ Web projesi: 
  ![Asp.NET Web API](https://img.shields.io/badge/asp.net%20web%20api-%231BA3E8.svg?style=for-the-badge&logo=dotnet&logoColor=white)
- ✅ Veri tabanı: 
  ![MsSQL Server](https://img.shields.io/badge/mssql%20server-%23CC2927.svg?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
- ✅ Dökümantasyon için:
  ![Postman](https://img.shields.io/badge/postman-%23FF6C37.svg?style=for-the-badge&logo=postman&logoColor=white)
  ![Swagger](https://img.shields.io/badge/swagger-%2385EA2D.svg?style=for-the-badge&logo=swagger&logoColor=black)
- ✅ Mimari: 
  ![Onion Mimarisi](https://img.shields.io/badge/onion%20mimarisi-%237D7D7D.svg?style=for-the-badge&logo=generic&logoColor=white)
- ✅ Kullanılan Pattern'ler:
  ![MediatR](https://img.shields.io/badge/mediatr-%238B008B.svg?style=for-the-badge&logo=generic&logoColor=white)
  ![CQRS](https://img.shields.io/badge/cqrs-%23121011.svg?style=for-the-badge&logo=generic&logoColor=white)


#### PROJEDE KULLANILAN TEKNOLOJİLER VE KÜTÜPHANELER 🛠️
<p>
  <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" />
  <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />
  <img alt="Entity Framework" src="https://img.shields.io/badge/entity%20framework-%2358B9C9.svg?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img alt="NArchGen" src="https://img.shields.io/badge/narchgen-%23003A70.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="JWT" src="https://img.shields.io/badge/jwt-%23FFA500.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="AutoMapper" src="https://img.shields.io/badge/automapper-%23228B22.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="FluentValidation" src="https://img.shields.io/badge/fluentvalidation-%23563D7C.svg?style=for-the-badge&logo=generic&logoColor=white" />
  <img alt="Dapper" src="https://img.shields.io/badge/Dapper-ORM-blue?style=for-the-badge" />
  <img alt="Visual Studio" src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visualstudio&logoColor=white" />
  <img alt="Github" src="https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white" />
</p>


#### 📫 NASIL BİR PROJE OLUŞTURDUK?
<p>Bu proje, şirketlerde personelinin masraf girişlerinin takibi, onay süreci, ödeme simülasyonu ve raporlanması gibi işlemleri yönetmek amacıyla geliştirilen bir saha masraf yönetimi sistemidir.</p>

➡️ 1- Admin/Yönetici 

- ✅Gelen masraf taleplerini onaylayabilir.
- ✅ Gelen masraf taleplerini reddebilir.
- ✅ Onaylanan masraf taleplerine sanal ödeme işlemi uygulayabilir.
- ✅ Personel bazlı, tarih aralıklı, kategori bazlı harcama raporlarını görebilir.
- ✅ Şirketin günlük,haftalık ve aylık ödeme yoğunluğu raporlarını görebilir.
- ✅Şirketin personel bazlı günlük,haftalık ve aylık harcama yoğunluğunu raporlarını görebilir.
- ✅ Şirketin günlük,haftalık,aylık onaylanan ve red edilen masraf miktarları raporlarını görebilir.
- ✅Kullanıcıları listeleyebilir, kullanıcı oluşturabilir.
- ✅ Kullanıcılara rol atayabilir (Admin / Personel).
- ✅ 	Kategori oluşturma, silme işlemleri yapabilir.
- ✅ 	Yeni ödeme aracı ekleyebilir veya düzenleyebilir.

ve daha fazlası ... :)

➡️ 2- Employee/Personel 
- ✅ Tutar, açıklama, kategori gibi bilgilerle sadece kendine ait yeni bir masraf talebi gönderir.
- ✅ Masraf talebine ait fatura, fiş gibi belgeleri yükleyebilir.
- ✅ Sadece kendisine ait talepleri listeleyebilir.
- ✅ Talebin durumu, tutarı, ödeme bilgilerini inceleyebilir.
- ✅ Kendi taleplerini ve detaylarını gösteren raporları görebilir.
      
 ve daha fazlası...

## PROJE DETAYLARI📝

Proje, .Net 8, ile geliştirilen modern bir web uygulamasıdır. Projemizde MsSQL kullanılmış olup, dökümantasyon için Swagger entegrasyonu sağlanmıştır.
Projede, **Onion mimarisi**, **Mediatr** ve **CQRS (Command Query Responsibility Segregation)** pattern'leri kullanılarak daha modüler ve yönetilebilir bir yapı sağlanmıştır. Veritabanı işlemleri için **Entity Framework** kullanılmış ve **Code First** yaklaşımı benimsenmiştir.
Projede silme işlemleri **Soft Delete (yumuşak silme)** mantığıyla gerçekleştirilmiştir. Yani, bir veri silindiğinde fiziksel olarak veritabanından tamamen kaldırılmak yerine, ilgili kaydın DeletedDate alanı doldurularak silinmiş gibi işaretlenir. 
Bu sayede; Veriler sistemsel olarak silinmiş gibi işlenirken,Raporlama, geçmiş inceleme veya loglama gibi işlemler için kayıtlar erişilebilir kalır. Veri kaybı önlenmiş olur.

🧰 Ek olarak, projede şu önemli kütüphaneler ve araçlar kullanılmaktadır:
- **AutoMapper**: Nesneler arası dönüşümleri kolaylaştırmak için.
- **FluentValidation**: Veri doğrulama süreçlerini yönetmek için.
- **JWT (JSON Web Token)**: Kimlik doğrulama ve yetkilendirme işlemlerini güvenli bir şekilde gerçekleştirmek için.
- **Dapper**: Performans odaklı veri erişimi ve özellikle raporlama işlemleri için, doğrudan SQL sorgularıyla çalışarak daha hızlı sonuçlar elde etmek için kullanılır.

Bu sayede, projemiz yüksek performanslı, kolay yönetilebilir ve güvenli bir mimariye sahip olmuştur.

🎯Projede veri tabanı bağlantı yolunu appsetting.development.json içinde yazılmıştır. Bunu yaparak uygulama içerisine bağlantı kodlarımızı yazmak yerine daha genel bir yerde kolay bir şekilde yönetilmesini sağlanmıştır. Böylece bir havuzdaki musluklar gibi hangisini istenilirse o musluktan verilerin çekilmesi sağlanmıştır.

```c#
  "AllowedHosts": "*",
 "ConnectionStrings": {
   "MsSqlConnectionString": "Server=MERVE_KARATAS\\SQLEXPRESS; Database=FieldExpense ;Trusted_Connection=True ;Encrypt=False;"
 }
```

🔒 Projemizin katmanları aşağıda gösterilmiştir.Projemizin yapısını ve içeriği katman katman aşağıdan inceleyebilirsiniz.:

</br>
<img width="200" alt="image" src="https://github.com/user-attachments/assets/cd4096c4-553a-41a6-946f-6b6b5ee5ceec" />
</br>

-----------------------------------------------------------------------
## 🌱DOMAIN KATMANI

<p>📌 Domain katmanı temel veri modellerini barındıran katmandır.</p> 

<img width="300" alt="image" src="https://github.com/user-attachments/assets/26554433-5ad9-44eb-8b6d-994a60e82d5d" />

<p></br>
  ✎ Domain katmanınındaki klasörleri açıklayalım.
  
<p>📂 Entities  ----> Uygulamanın temel varlık sınıflarını (entities) içerir. Bu sınıflar gereksiz kod tekrarını önlemek adına core katmanında bulunan base class olan Entity sınıfından miras alır.Base entity Id, CreatedDate, UpdatedDate, DeletedDate gibi ortak özellikleri içerir.
   Bu entity classı core katmanında daha detaylı inceledik oradan bakabilrsiniiz. </p>

Oluşturulan Entityler

- ⚡ExpenseCategory, masrafın ait olduğu kategori bilgisini tutar.
- ⚡PaymentMethod, masrafın hangi ödeme yöntemiyle yapıldığını belirtir (örneğin nakit, kredi kartı).
- ⚡ExpenseRequest, kullanıcılar tarafından oluşturulan masraf taleplerini tutar.
- ⚡BankTransaction, ödemesi yapılmış masraflara ilişkin banka işlem bilgilerini tutar.
- ⚡Role, kullanıcı rollerini (Admin, Personel gibi) tutar.
- ⚡User, sistemdeki kullanıcıların temel bilgilerini tutar.c</p> 

   Aşağıda örnek olarak ExpenseCategory Entity dosyasını görebilirsiniz. 
```c#

 public class ExpenseCategory : Entity<int>
 { 
     public string Name { get; set; }
     public virtual ICollection<ExpenseRequest> ExpenseRequests { get; set; }
 }
```
<p>📂 Enums ----->Uygulamada kullanılan sabit veri türlerini (enum) barındırır. Örneğin: TransactionStatus, DateRangeType,  gibi sabit değerlerin tanımlandığı yapılar burada yer alır. Kodun daha okunabilir, güvenli ve anlamlı olmasını sağlar.</p> 

```c#
 public enum ExpenseStatus
 {
     Bekliyor = 0,    // Pending
     Onaylandı = 1,   // Approved
     Reddedildi  = 2   // Rejected
 }
```

-----------------------------------------------------------------------
## 🌱PERSISTENCE KATMANI

 <p></br>📌 Persistence katmanı, uygulamanın veri tabanı ile olan etkileşimini düzenleyerek, veri saklama işlemlerinin güvenli ve etkili bir şekilde yönetilmesini sağlayan katmandır.</br></p> 


<img width="400" alt="image" src="https://github.com/user-attachments/assets/b6a0ca0a-17ae-4baf-9199-8e051f7aa1ff" />


<p></br>
✎ Persistence katmanınındaki klasörleri açıklayalım. </p>
  
 <p>📁  Contexts ----> İçerisinde entity sınıflarının veri tabanı modellerine karşılık gelecek olan tabloların oluşturulması için BaseDbContext sınıfı bulunmaktadır.  </p>
 
🔎  BaseDbContext, 
- ⚡ Entity Framework Core kullanılarak oluşturulan ve uygulamadaki veritabanı işlemlerini yöneten temel sınıftır. Uygulamadaki tüm tablo karşılıklarını (DbSet) içerir:Users, Roles, ExpenseRequests, ExpenseCategories, PaymentMethods, BankTransactions
- ⚡ Ayrıca: SaveChanges ve SaveChangesAsync metodları içinde oluşturulma, güncellenme ve yumuşak silme (soft delete) işlemleri için otomatik tarih atama işlemleri yapılır (CreatedDate, UpdatedDate, DeletedDate).
- ⚡ OnModelCreating metodu ile Entity Configuration sınıfları otomatik olarak yüklenir. (ApplyConfigurationsFromAssembly).


 <p></br>📌 Aşağıda BaseDbContext sınıfı örnek olarak verilmiştir. Diğer sınıfları projeden inceleyebilirsiniz. </p>


```c#
  public class BaseDbContext:DbContext
  {
      protected IConfiguration Configuration { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Role> Roles { get; set; }
      public DbSet<PaymentMethod> PaymentMethods { get; set; }
      public DbSet<ExpenseRequest> ExpenseRequests { get; set; }
      public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
      public DbSet<BankTransaction> BankTransactions { get; set; }


      public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
     : base(dbContextOptions)
      {
          Configuration = configuration;
      }

      public override int SaveChanges()
      {
          ApplyEntityTimestamps();
          return base.SaveChanges();
      }

      public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
      {
          ApplyEntityTimestamps();
          return await base.SaveChangesAsync(cancellationToken);
      }
      private void ApplyEntityTimestamps()
      {
          var entries = ChangeTracker.Entries()
              .Where(e => e.Entity is Entity<int> &&
                     (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

          foreach (var entry in entries)
          {
              var entity = (Entity<int>)entry.Entity;

              switch (entry.State)
              {
                  case EntityState.Added:
                      entity.CreatedDate = DateTime.UtcNow;
                      break;

                  case EntityState.Modified:
                      entity.UpdatedDate = DateTime.UtcNow;
                      break;

                  case EntityState.Deleted:
                      entity.DeletedDate = DateTime.UtcNow;
                      entry.State = EntityState.Modified; // Soft delete
                      break;
              }
          }
      }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      }
  }
```

<p></br>
📁 EntityConfigurations ----> Entity sınıflarının veritabanı şemalarını yapılandırmak için kullanılan konfigürasyon sınıfları bulunmaktadır.
</p>
<p></br>🖋 Code First yaklaşımı ile kullanılan veri tabanı modellerini(entity) ve ilişkilerinin yapılandırılmasını sağlamak için bir yol olan Fluent Api ile modellerin konfigürasyonlarını gerçekleştirilmiştir. Örnek olarak yukarıda verilen ExpenseCategory sınıfın konfigürasyon kodları gösterilmiştir. </p>

</br>

```c#
  public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
  {
      public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
      {

          builder.ToTable("ExpenseCategories").HasKey(ec => ec.Id);
          builder.Property(ec => ec.Name).IsRequired().HasMaxLength(100);
          builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

          builder.HasMany(ec => ec.ExpenseRequests)
             .WithOne(er => er.ExpenseCategory)
             .HasForeignKey(er => er.ExpenseCategoryId)
             .OnDelete(DeleteBehavior.Restrict);
      }
  }
```

<p>📁 Repositories----> Her entity sınıfının veri tabanı işlemlerini gerçekleştirmek için oluşturulan repository sınıfları bulunmaktadır. Bu projede Generic Repository yaklaşımı kullanılmaktadır. Ortak veri erişim işlemleri (Add, Update, Delete, GetById, vs.) Core katmanında bulunan EfRepositoryBase adlı sınıfta tanımlanmıştır.
  Her entity için sadece kendi özel ihtiyaçları varsa override edilebilecek şekilde, bu base sınıftan türetilmiş repository sınıfları yer alır.Örnek olarak yukarıda verilen ExpenseCategory sınıfının repository sınfına ait kodları gösterilmiştir.
</br>
</p>
 
 ```c#
   public class BankTransactionRepository : EfRepositoryBase<BankTransaction, int, BaseDbContext>, IBankTransactionRepository
   {
       public BankTransactionRepository(BaseDbContext context) : base(context)
       {
       }

   }
```
<p>
📊İşlemler tamamlandıktan sonra migration işlemi yapılarak modeller veri tabanına yansıtılmıştır. Aşağıda oluşturulan veritabanındaki tabloların diyagramı gösterilmektedir.Diyagramdan da entityler arasındaki ilişkileri inceleyebilirsiniz.
</br>
</p>
 

<img width="713" alt="image" src="https://github.com/user-attachments/assets/8870fad9-d2f2-43b9-bda7-08ee016a2af6" />


-----------------------------------------------------------------------
## 🌱APPLICATION KATMANI
<p>📌 Application katmanı, iş mantığı (business logic) ile veri erişimi arasındaki bağlantıyı sağlayan katmandır. CQRS desenine uygun olarak komutlar (Commands) ve sorgular (Queries) bu katmanda yer alır. Ayrıca servisler ve repository arayüzleri de burada tanımlanır.</p>

<img width="400" alt="image" src="https://github.com/user-attachments/assets/1bd394e8-4c66-44d2-9c8d-79c869396bc6" />

</br>
<p> 



<p>✎ Application katmanınındaki klasörleri açıklayalım.</p> 
<p>📁 Features ----> Bu klasör altında, CQRS deseninden faydalanılarak her bir Entity için gerekli olan Command ve Query sınıfları ile bunlara ait Validator ve AutoMapper profilleri oluşturulmuştur. Her Entity'nin kendi Feature klasörü altında bu yapılar düzenli şekilde yer alır.
</br> </p>
      <img width="200" alt="image" src="https://github.com/user-attachments/assets/61c7f280-f6b1-44c9-bd61-eba2b2932c38" />

<p></br>
  🔔 Not:
  </br>
ExpenseRequests klasörü altında Commands ve Queries klasörleri kendi içinde Admin, Employee ve Common adında alt klasörlere ayrılmıştır. Bu yapı sayesinde:
- Yetki bazlı işlemler daha okunabilir ve yönetilebilir hale gelmiştir.
- Swagger üzerinde endpointlerin düzenli ve anlaşılır bir şekilde gruplanması sağlanmıştır.
Örneğin:
- Yalnızca Admin yetkisine ait masraf onaylama, reddetme ve ödeme işlemleri Admin klasöründe yer alır.
- Personelin yalnızca kendi işlemlerini kapsayan talepler Employee klasöründe yer alır.
- Ortak işlemler (Create, Update, Delete, GetById, GetList) Common klasöründe tanımlanmış, fakat rol kontrolleri ISecuredRequest üzerinden yapılmıştır.

Bu yapı sadece fonksiyonel ayrımı kolaylaştırmak ve okunabilirliği artırmak amacıyla tercih edilmiştir.Aynı yapı Reports feature altında da tercih edilmiştir.
</br>
</p>
<img width="190" alt="image" src="https://github.com/user-attachments/assets/a909966b-8a8c-4a46-b182-3860879ccf10" />


<p></br> Aşağıda Fluent Validation kütüphanesi kullanılarak command için oluşturulan validator sınıfı örnek olarak verilmiştir. Diğer sınıfları projeden inceleyebilirsiniz.</p>

```c#
 public class CreateExpenseCategoryValidator : AbstractValidator<CreateExpenseCategoryCommand>
 {
     public CreateExpenseCategoryValidator()
     {
         RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");
     }
 }
```
<p> 🔎 Böylece daha Controller tarafında istek atılmadan requestlerin istenilen kurallara uygun olup olmadığı kontrol edilir.

📁 Repositories ----->Bu klasör, her Entity’ye ait repository arayüzlerini içerir. Bu yapı sayesinde:
- Kodun test edilebilirliği artar.
- Bağımlılıklar daha yönetilebilir hale gelir.
  
 Aşağıda IExpenseCategoryRepository sınıfı örnek olarak verilmiştir. Diğer sınıfları projeden inceleyebilirsiniz.


IExpenseCategoryRepository, ExpenseCategory varlığına ait veritabanı işlemlerini senkron ve asenkron olarak yöneten özel repository arayüzüdür.
</br>

</p>

```c#
  public interface IExpenseCategoryRepository : IRepository<ExpenseCategory, int>, IAsyncRepository<ExpenseCategory, int>
  {
  }
 ```
 <p>
   
📁 Services----->Bu klasör, uygulama servislerini barındırır. Servisler, özellikle handler sınıflarında kullanılmak üzere mantıksal işlemleri içerir.

Alt klasörlerdeki servisler şunları sağlar:
- ⚡AuthService → Kimlik doğrulama işlemleri
- ⚡BankTransactionService → Banka işlemleri
- ⚡ExpenseCategory → Masraf kategori işlemleri
- ⚡ExpenseRequestService → Masraf talebi işlemleri
- ⚡FileService → Dosya yükleme/silme işlemleri
- ⚡PaymentGatewayService → Ödeme işlemleri simülasyonu
- ⚡PaymentMethodService →Ödeme yöntemleri işlemleri
- ⚡ReportService → Raporlama verilerini hazırlar
- ⚡RoleService → Rol işlemleri
- ⚡UserService  → Kullanıcı işlemleri
</br>
</p>

-----------------------------------------------------------------------
## 🧠 CORE KATMANI
📌 Core katmanı, projede katmanlar arası bağımlılıkların en aza indirildiği, soyutlama odaklı, merkezi iş kurallarını ve yardımcı servisleri içeren altyapı katmanıdır. Diğer tüm katmanlardan referans alınabilir ancak bu katman hiçbir başka katmana bağımlı değildir.
<p><img width="182" alt="image" src="https://github.com/user-attachments/assets/b797d3b2-c80f-492d-9da9-b3b443f02b1d" /></p>

</br>
<p>
- 📂 Application Klasörü
  Bu klasör, Clean Architecture prensiplerine uygun olarak iş mantığına ait temel yapıların tanımlandığı alandır.

   - 📁 Pipelines:
     MediatR ile gelen isteklerin işlenmeden önce geçtiği pipeline’ları içerir. Örneğin:
       - Authorization: Roller bazlı yetkilendirme işlemleri.
       - Validation: FluentValidation kurallarının kontrol edildiği ara katman.

- 📁 CrossCuttingConcerns:
   Katmanlar arası tekrar eden işlemleri (örnek: hata yönetimi) kapsar.
       - Exceptions: Projede global exception handling için kullanılan sınıflar, ExceptionMiddleware ile birlikte yapılandırılmıştır.
       - HttpProblemDetails: API hata mesajlarının RFC7807 standartlarına uygun olarak şekillenmesini sağlar.

- 📁 Entities:
    Projedeki temel varlıkların (Entity) soyutlamalarını içerir.
        - BaseUser, BaseRole: Uygulamanın temel kullanıcı ve rol modelleridir, diğer sınıflar bunlardan türetilir.
        - IEntity, IEntityTimestamps: Tüm Entity sınıflarının uygulaması beklenen interface'lerdir. (Id, CreatedDate, UpdatedDate gibi alanlar için ortak yapı sağlar.)

- 📁 Persistence:
    Entity Framework Core tabanlı temel Repository sınıflarının tanımlandığı bölümdür.
        - EfRepositoryBase: Tüm repository sınıflarının kalıtım alabileceği generic EF tabanlı repository yapısı.
        - IRepository, IAsyncRepository: Senkron ve asenkron veri işlemleri için ortak interface yapıları.

Bu yapı sayesinde, veri erişim kodları soyutlanmış olur ve farklı ORM'ler (örneğin Dapper) ile geçiş esnekliği kazanılır.
</br>
</p>

<p>
🔐 Utilities Klasörü
Yardımcı sınıflar ve sistemde genel amaçla kullanılan araçlar bu klasörde toplanır.

- 📁 Encryption:
  Güvenli anahtar üretimi için kullanılır.
     - SecurityKeyHelper: JWT token'lar için simetrik anahtar üretimi sağlar.

- 📁 Hashing:
   Parola işlemlerinde kullanılan SHA512 tabanlı hashing işlemleri burada tanımlanır.
     - HashingHelper: Şifreleme ve şifre doğrulama işlemleri içerir.
 
- 📁 JWT:
   Kimlik doğrulama için kullanılan JSON Web Token işlemleri.
      - AccessToken: Token nesnesinin modelidir.
      - ITokenHelper, JwtHelper: JWT üretimi, doğrulaması ve kullanıcı bilgileri ile token oluşturma işlemleri.
      - TokenOptions: JWT ayarlarının (issuer, audience, security key) yansıtıldığı konfigürasyon sınıfı.

🧩 CoreServiceRegistration.cs
Bu sınıf, Core katmanındaki bağımlılıkların dışarıya servis olarak sunulması için tanımlanmış ServiceCollection uzantısıdır. DI konteynerine gerekli servislerin eklenmesini sağlar.
</br>
</p>

-----------------------------------------------------------------------
## 🏗️ INFRASTRUCTURE KATMANI
📌 Infrastructure katmanı, uygulamanın dış servislerle olan etkileşimlerini ve altyapı bağımlılıklarını yöneten katmandır. Veri erişim, dosya yönetimi, ödeme altyapısı gibi dış kaynaklarla ilgili işlemler burada soyutlanarak gerçekleştirilir.
<p><img width="200" alt="image" src="https://github.com/user-attachments/assets/a52d995a-101f-42d2-a088-050cee4d979d" /></p>

- 📂 Contexts Klasörü
  - DapperContext.cs: Uygulamada Dapper ile veritabanı işlemleri yapılacaksa, bu işlemleri yöneten IDbConnection nesnesi bu sınıf aracılığıyla oluşturulur.
         - Bağlantı string’ini appsettings.json dosyasından alır.
         - SQL tabanlı manuel sorgular için altyapı sağlar.

- 📂 Services Klasörü
   Bu klasör, dış servislerle iletişimi sağlayan somut servis sınıflarını içerir.
     - 📁 File
        - FileManager.cs: Dosya yükleme, silme ve erişim işlemlerini içerir. Özellikle kullanıcıların belge, fatura gibi dosyalarını sisteme yüklemesi için kullanılır.
          - 🔹 Örnek işlemler: UploadFile, DeleteFile, GetFilePath
     - 📁 PaymentGateway
        - PaymentGatewayManager.cs: Ödeme işlemlerini simüle eden sınıftır. Gerçek bir sanal POS entegrasyonu yerine, örnek olarak dummy ödeme işlemleri yürütür.
         - 🔹 Örnek: Talep edilen ödemenin başarılı ya da başarısız sonuçlarını simüle eder.
     - 📁 Report
        - ReportManager.cs: Rapor verilerini hazırlayan sınıftır. Dapper kullanılarak karmaşık sorguların performanslı şekilde çalıştırılması sağlanır.
         - 🔹 Örnek: Masraf raporları, toplam giderler, kullanıcı bazlı özetler.

🧩 InfrastructureServiceRegistration.cs
Bu sınıf, Infrastructure katmanında yer alan servislerin Dependency Injection sistemine eklenmesini sağlayan uzantı metodudur. Örneğin:

```c#
services.AddScoped<IFileService, FileManager>();
services.AddScoped<IPaymentGatewayService, PaymentGatewayManager>();
services.AddScoped<IReportService, ReportManager>();
```
Bu yapı sayesinde uygulamanın servis bağımlılıkları merkezi bir şekilde yönetilir ve servisler kolayca test edilebilir hale gelir.

-----------------------------------------------------------------------

## 🌐WEBAPI KATMANI
📌 WebAPI katmanı, istemcilerle (frontend, mobil, Postman vb.) doğrudan iletişim kurulan katmandır. Uygulamanın dış dünyaya açılan kapısıdır ve genellikle RESTful servisler burada tanımlanır. Controller’lar sayesinde HTTP istekleri alınır ve gerekli iş akışı başlatılır.

- 📁 Controllers 
  - API’nin uç noktalarını (endpoints) tanımlayan sınıflar burada yer alır.
  - Controller’lar, ilgili servisleri veya CQRS handler’larını çağırarak işlem akışını başlatır.

```c#
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetListExpenseRequestQuery());
            return Ok(result);
        }
```
   
Projede 14 adet Controller sınıfı bulunmaktadır.Bunlardan bazıları Narchgen Code Generator ile hazır gelen Controller sınıfları olup aşağıda gösterilmiştir.

- ⚡ AuthController, yetkilendirme işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ BaseController, diğer Controller sınıflarının miras aldığı Base yapı amacıyla kullanılır.
- ⚡ OperationClaimsController, rollerinin ayarlandığı sınıftır.
- ⚡ SmsSimulationController, SMS yollama işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ UsersController, kullanıcı işlemlerinin gerçekleştirildiği sınıftır.
- ⚡ UserOperationClaimsController, kullanıcı rollerinin ayarlandığı sınıftır.
  
Proje isterlerine göre eklenen Controller sınıfları ise şunlardır;

- ⚡ AdminExpenseRequestsController, yöneticiler için harcama taleplerini yönetir. Onaylama, reddetme gibi işlemleri içerir.
- ⚡ AdminReportsController, yöneticilere özel sistemsel raporları üretir ve filtreleme işlevselliği sağlar.
- ⚡ AuthController, kullanıcı kimlik doğrulama işlemlerini (giriş, çıkış, token yenileme) gerçekleştirir.
- ⚡ BankTransactionsController, banka işlemleriyle (havale, EFT, bakiye görüntüleme vb.) ilgili uç noktaları içerir.
- ⚡ EmployeeExpenseRequestsController, çalışanların kendi harcama taleplerini oluşturmasını ve görüntülemesini sağlar.
- ⚡ EmployeeReportsController, çalışanlara özel raporları oluşturur ve veri analizlerini sunar.
- ⚡ ExpenseCategoriesController, harcama kategorilerinin listelenmesi, eklenmesi ve güncellenmesi gibi işlemleri içerir.
- ⚡ ExpenseRequestsController, genel harcama taleplerinin CRUD işlemlerini yürütür.
- ⚡ PaymentMethodsController, Ödeme yöntemlerinin yönetimini sağlar (örneğin kredi kartı, banka hesabı).
- ⚡ RolesController, kullanıcı rollerini (Admin, Employee vb.) ve yetkilendirmeyi yönetir.
- ⚡ UsersController, kullanıcı hesaplarının oluşturulması, güncellenmesi ve silinmesini sağlar.


🛠️ Program.cs
- Uygulamanın başlangıç noktasıdır.
- Servislerin (Service, Repository, Middleware vb.) DI (Dependency Injection) sistemine eklendiği yerdir.
- Uygulama pipeline’ı (middleware sırası, hata yönetimi, Swagger vb.) burada yapılandırılır.

⚙️ appsettings.json
- Uygulama genel ayarları burada tanımlanır.
- Veritabanı bağlantı bilgileri
- JWT token ayarları
- Harici servis URL’leri

🌐 wwwroot Klasörü
- Statik dosyaların (resim, CSS, JavaScript vb.) barındırıldığı klasördür.
<img width="134" alt="image" src="https://github.com/user-attachments/assets/d14e5bc0-1575-4bdc-b996-81ddb84faa83" />
 Uygulamanın dosyaları bu klasörde tutulmaktadır.




-----------------------------------------------------------------------

### 🔐 JWT ile Kimlik Doğrulama (Authentication & Authorization)
<p> 📌 Bu projede kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için JWT (JSON Web Token) mimarisi kullanılmıştır. JWT, istemci ile sunucu arasında kimlik doğrulama bilgisini güvenli ve şifrelenmiş bir şekilde taşıyan, imzalanmış token yapısıdır.
Uygulama giriş işlemi sonrasında kullanıcıya bir token üretilir. Bu token, her istekte HTTP Header içinde sunucuya gönderilerek kimlik doğrulama ve yetki kontrolü yapılmasını sağlar. </p> <p> Uygulama katmanında `ITokenHelper` ve `JwtHelper` sınıfları ile token üretimi ve doğrulama işlemleri gerçekleştirilmiştir.
`AccessToken` içinde kullanıcının rolü ve kimlik bilgileri yer alır. Bu sayede kullanıcı, hangi endpointlere erişebileceği konusunda kontrol altında tutulur. </p> <p>Authentication işlemi başarıyla tamamlandıktan sonra üretilen token aşağıdaki örnekte olduğu gibi kullanıcıya döndürülür:</p>

```c#              
Role userRole = await _roleRepository.GetAsync(i => i.Id == user.RoleId);
var userRoles = new List<Core.Entities.BaseRole> { userRole };
return _tokenHelper.CreateToken(user, userRoles);
```

<p> Yetki kontrolü ise CQRS komutlarında `ISecuredRequest` arayüzü üzerinden yapılır. Bu sayede ilgili role sahip olmayan kullanıcılar, tanımlı olmayan işlemleri gerçekleştiremez: </p>

```c# 
  public class CreateExpenseCategoryCommand : IRequest<CreateExpenseCategoryResponse>,ISecuredRequest
  {
      public string[] RequiredRoles => ["Admin"];
   } 
```
----------------------------------------------------------------------

### 📊 Dapper ile Raporlama ve Hızlı Veri Erişimi
<p> 📌 Projede, raporlama işlemleri ve performans odaklı veri çekme ihtiyaçları için **Dapper** mikro ORM kütüphanesi kullanılmıştır. Dapper, doğrudan SQL sorguları ile çalışarak Entity Framework'e göre daha hızlı sonuç üretir ve özellikle veri analizinde tercih edilir. </p>
<p> Raporlama işlemleri için özel View ve Stored Procedure (SP) tanımlamaları yapılmıştır. Bu yapılar sayesinde çok sayıda filtreleme ve birleştirme işlemi daha verimli şekilde gerçekleştirilmektedir.</br> </p>


```c#
    public class ReportManager:IReportService
    {
        private readonly IDbConnection _connection;

        public ReportManager(DapperContext context)
        {
            _connection = context.CreateConnection();
        }

      
        public async Task<List<GetUserExpenseReportResponse>> GetExpenseRequestsByUserIdAsync(int userId)
        {
            string query = @"SELECT * FROM V_ExpenseRequestDetails WHERE UserId = @UserId";
            var result = await _connection.QueryAsync<GetUserExpenseReportResponse>(query, new { UserId = userId });
            return result.ToList();
        }
}


```

-----------------------------------------------------------------------
<p> 📌 Projenin çalışır halinin ekran görüntülerine ait dosyasına <a href="https://drive.google.com/file/d/1Q7mqndQn31VuwIUrZkpJCXzhyQg1p4Sj/view"> buradan </a> ulaşabilirsiniz. </p>

-----------------------------------------------------------------------

Görüşürüz 🎉 
