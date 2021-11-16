<script>

  let kullaniciAdi='';
  let sifre='';

  async function GirisYap(){
  
   let res =  await fetch('https://localhost:44364/api/Auth/SignIn',
    {
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        method: "POST",
        body: JSON.stringify({kullaniciAdi:kullaniciAdi, sifre: sifre})
    })
    .then(function(res){ 
      
      return res.json()
    })
    .catch(function(res){ 
      
      //hata durumu 
      console.error("message", res);
    });
    localStorage.setItem("Token", "Bearer " + res.data)
  }
</script>
<div class="text-center mb-4">
    <a href="."><img src="./static/logo.svg" height="36" alt=""></a>
  </div>
  <form class="card card-md"  on:submit|preventDefault={GirisYap} >
    <div class="card-body">
      <h2 class="card-title text-center mb-4">Giriş yap veya kayıt ol</h2>
      <div class="mb-3">
        <label class="form-label">Kullanıcı adı</label>
        <input type="text" class="form-control" bind:value={kullaniciAdi} placeholder="Kullanıcı adı giriniz">
      </div>
      <div class="mb-2">
        <label class="form-label">
          Şifre
          <span class="form-label-description">
            <a href="/forgot-password">Şifremi unuttum</a>
          </span>
        </label>
        <div class="input-group input-group-flat">
          <input type="password" class="form-control"  bind:value={sifre} placeholder="Password"  autocomplete="off">
          
        </div>
      </div>
      <div class="form-footer">
        <button type="submit"  class="btn btn-primary w-100">Giriş Yap</button>
      </div>
    </div>
  </form>
  <div class="text-center text-muted mt-3">
    Hesabınız yokmu ? <a href="./sign-up" tabindex="-1">Kayıt Ol</a>
  </div>