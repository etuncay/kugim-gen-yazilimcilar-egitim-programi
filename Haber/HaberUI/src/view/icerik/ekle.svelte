<script>
     import { quill } from "svelte-quill";
     const options = { }

    let baslik ='';
    let icerikTipi ='';
    let kategoriId ='';
    let resimUrl ='';
    let resim ='';
    let ozet ='';
    let govde ='';
    let kategoriler = [];    
    
    (async () => {

    const rawResponse = await fetch('https://localhost:44364/api/Kategori/Listele', {
        method: 'GET',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        }
    });
    const content = await rawResponse.json();

        kategoriler = content.data;


    })();



    async function Ekle(){
        let postData ={
            
                baslik: baslik,
                icerikTipi : icerikTipi,
                kategoriId: kategoriId,
                resimUrl: resimUrl,
                ozet: ozet,
                govde: govde
                
            };

        let result = await fetch("https://localhost:44364/api/Icerik/Ekle",
      {
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          method: "POST",
          body: JSON.stringify(postData)
      })
      .then(function(res){ 
        return res.json();
       });

      if(result.type=='Success'){
        location.href = '/icerik/liste';
      }else{

      }
    }

    async function ResimYukle(){
      
      let postData = new FormData();
      
      postData.append('file', resim.files[0])


      let result = await fetch("https://localhost:44364/api/File/Yukle",
      {
         
          method: "POST",
          body: postData
      })
      .then(function(res){ 
        return res.json();
      });

      if(result.type=='Success'){
        resimUrl = result.data;
      }else{
        alert(result.message)
      }
    }

</script>
<svelte:head>
	<link href="//cdn.quilljs.com/1.3.6/quill.snow.css" rel="stylesheet">
</svelte:head>

<div class="container-xl">
    <!-- Page title -->
    <div class="page-header d-print-none">
      <div class="row align-items-center">
        <div class="col">
          <h2 class="page-title">
            içerik Ekle
          </h2>
        </div>
      </div>
    </div>
  </div>
  <div class="page-body">
    <div class="container-xl">
        <div class="card">
            <div class="card-header">
              <h3 class="card-title">İçerik Ekleme Formu</h3>
            </div>
            <div class="card-body">
              <form on:submit|preventDefault={Ekle} >
                <div class="form-group mb-3 row">
                  <label class="form-label col-3 col-form-label">Başlık</label>
                  <div class="col">
                    <input type="text" class="form-control" bind:value={baslik} placeholder="içerik için uygun bir başlık giriniz">
                    <small class="form-hint">başlık giriniz</small>
                  </div>
                </div>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Resim</label>
                    
                    <div class="col">
                      <input type="file" class="form-control" on:change={ResimYukle} bind:this={resim}>
                      <small class="form-hint">resim seçiniz</small>
                    </div>
                    <img src={resimUrl} style="width: 250px;">
                  </div>
                  
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">İçerik Tipi</label>
                    <div class="col">
                      <select bind:value={icerikTipi}>
                            <option selected value="1">Haber</option>
                            <option value="2">Galeri</option>
                        </select>
                    </div>
                  </div>
                  <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Kategori</label>
                    <div class="col">
                      <select bind:value={kategoriId}>
                        <option  value="">Seçim Yapınız</option>
                        {#each kategoriler as kategori,  i}
                            <option value="{kategori.id}">{kategori.ad}</option>
                        {/each}
                      </select>
                    </div>
                  </div>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Özet</label>
                    <div class="col">
                        <div class="editor" use:quill={options} on:text-change={e => ozet = e.detail.html}></div>
                    </div>
                  </div>
                  <br><br>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Gövde</label>
                    <div class="col">
                        <div class="editor" use:quill={options} on:text-change={e => govde = e.detail.html}></div>
                  </div>
                <div class="form-footer">
                  <button type="submit" class="btn btn-primary">Gönder</button>
                </div>
              </form>
            </div>
          </div>
    </div>
</div>
