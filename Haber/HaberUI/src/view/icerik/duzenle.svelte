<script>
    import { quill } from "svelte-quill";
    import { Route } from 'svelte-router-spa'
    import { apiBaseUrl } from '../../const';
    export let currentRoute   
     const options = { }
    let id= currentRoute.namedParams.id;
    let baslik ='';
    let icerikTipi ='';
    let kategoriId ='';
    let resimUrl ='';
    let resim ='';
    let ozet ='';
    let govde ='';
    let kategoriler = [];  
    let tarih ='';

    (async () => {

    const rawResponse = await fetch(apiBaseUrl.concat('Kategori/Listele'), {
        method: 'GET',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        }
    });
    const content = await rawResponse.json();

    kategoriler = content.data;

    const icerikResponse = await fetch(apiBaseUrl.concat('Icerik/Getir?id='+id), {
            method: 'GET',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            }
        });
        const icerikContent = await icerikResponse.json();

            if(content.type=='Success'){
                const icerikData= icerikContent.data;
                baslik =icerikData.baslik;
                icerikTipi = icerikData.icerikTipi.value;
                kategoriId =icerikData.kategori.value;
                resimUrl =icerikData.resimUrl;
                ozet = icerikData.ozet;
                govde =icerikData.govde;
                tarih = icerikData.tarih;
                
            }else{
                alert(icerikContent.message)    
            }


})();


async function Duzenle(){
        let postData ={
                baslik :baslik,
                icerikTipi :icerikTipi,
                kategoriId :kategoriId,
                resimUrl :resimUrl,
                ozet :ozet,
                govde :govde,
                tarih: tarih
            };

        let result = await fetch(apiBaseUrl.concat('Icerik/Guncelle?id='+id),
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "PUT",
            body: JSON.stringify(postData)
        })
        .then(function(res){ 
            return res.json();
        });

        if(result.type=='Success'){
            location.href = '/icerik/liste';
        }
    }

    async function ResimYukle(){
      
      let postData = new FormData();
      
      postData.append('file', resim.files[0])


      let result = await fetch(apiBaseUrl.concat('File/Yukle'),
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
            İçerik Düzenle
          </h2>
        </div>
      </div>
    </div>
  </div>
  <div class="page-body">
    <div class="container-xl">
        <div class="card">
            <div class="card-header">
              <h3 class="card-title">İçerik Düzenleme Formu</h3>
            </div>
            <div class="card-body">
              <form on:submit|preventDefault={Duzenle} >
                <div class="form-group mb-3 row">
                  <label class="form-label col-3 col-form-label">Başlık</label>
                  <div class="col">
                    <input type="text" class="form-control" bind:value={baslik} placeholder="içerik için uygun bir başlık giriniz">
                  </div>
                </div>
                <div class="form-group mb-3 row">
                  <label class="form-label col-3 col-form-label">Tarih</label>
                  <div class="col">
                    <input type="datetime-local" class="form-control" bind:value={tarih} placeholder="Tarih bilgisini giriniz">
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
                      <select class="form-control" bind:value={icerikTipi}>
                        <option  value="">Seçim Yapınız</option>
                            <option  value={1}>Haber</option>
                            <option value={2}>Galeri</option>
                        </select>
                    </div>
                  </div>
                  <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Kategori</label>
                    <div class="col">
                      <select class="form-control" bind:value={kategoriId}>
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
                        <!--<div class="editor" use:quill={options}  on:text-change={e => ozet = e.detail.html}></div>-->
                       
                        <textarea class="form-control" bind:value={ozet}></textarea>
                    </div>
                  </div>

                  <br><br>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Gövde</label>
                    <div class="col">
                         <!--<div class="editor" use:quill={options}  on:text-change={e => govde = e.detail.html}></div>-->
                       
                         <textarea class="form-control" bind:value={govde}></textarea>
                  </div>
                <div class="form-footer">
                  <button type="submit" class="btn btn-primary">Gönder</button>
                </div>
              </form>
            </div>
          </div>
    </div>
</div>
