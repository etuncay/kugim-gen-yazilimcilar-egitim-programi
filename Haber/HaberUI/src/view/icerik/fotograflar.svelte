<script>
     import { quill } from "svelte-quill";
     const options = { }

    import { apiBaseUrl } from '../../const';

    import { Route } from 'svelte-router-spa'
    export let currentRoute   
    let icerikId= currentRoute.namedParams.id;

    let fotograflar = [];
    let resim = '';
    let aciklama = '';
    let resimUrl  = '';

    (async () => {

        const rawResponse = await fetch(apiBaseUrl.concat('Resim/Listele?icerikId='+icerikId), {
            method: 'GET',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            }
        });
        const content = await rawResponse.json();

            fotograflar = content.data;


    })();



async function Ekle(){
    let postData ={
            icerikId: icerikId,
            resimUrl: resimUrl,
            aciklama: aciklama
            
        };

    let result = await fetch(apiBaseUrl.concat('Resim/Ekle'),
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
    location.href = '/icerik/fotograflar/'+icerikId;
  }else{

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

    async function Sil(id){
      let onay = confirm("Silmek istediğinize eminmisiniz");
      if(onay){
       let result = await fetch(apiBaseUrl.concat('Resim/Sil?icerikId='+id),
          {
              headers: {
                  'Accept': 'application/json',
                  'Content-Type': 'application/json'
              },
              method: "Delete",
          })
          .then(function(res){ 
              return res.json();
          });
  
          if(result.type=='Success'){
            location.href = '/icerik/fotograflar/'+icerikId;

          }
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
  
  <div class="page-body">
    <div class="container-xl">
        <div class="card">
            <div class="card-header">
              <h3 class="card-title">İçerik Ekleme Formu</h3>
            </div>
            <div class="card-body">
              <form on:submit|preventDefault={Ekle} >
                
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Resim</label>
                    
                    <div class="col">
                      <input type="file" class="form-control" on:change={ResimYukle} bind:this={resim}>
                      <small class="form-hint">resim seçiniz</small>
                    </div>
                    <img src={resimUrl} style="width: 250px;">
                  </div>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Açıklama</label>
                    <div class="col">
                        <div class="editor" use:quill={options} on:text-change={e => aciklama = e.detail.html}></div>
                  </div>
                <div class="form-footer">
                  <button type="submit" class="btn btn-primary">Gönder</button>
                </div>
              </form>
            </div>
          </div>
          <hr>
          <div class="card">
            <div class="card-header">
                <h3 class="card-title">Fotograflar</h3>
              </div>
              <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-vcenter card-table">
                      <thead>
                          <tr>
                              <th  class="w-1">Sıra</th>
                              <th  style="width: 150px;">Resim</th>
                              <th>Açıklama</th>
                              <th class="w-1"></th>
                          </tr>
                      </thead>
                      <tbody>
                        {#await fotograflar}
                        <tr>
                          <td colspan="4">
                            Veriler güncelleniyor.
                          </td>
                        </tr>
                        {:then value}
                           {#if value!=null}
                                {#each value as item,  i}
                                    <tr>
                                    <td>{i+1}</td>
                                    <td><img style="height: 50px;" src={item.resimUrl} ></td>
                                    <td>{item.aciklama}</td>
                                    <td>
                                    <a href="#" on:click={() => Sil(item.id)}>Sil</a>
                    
                                    </td>
                                    </tr>
                                {/each}
                            
                            {:else}
                                <tr>
                                    <td colspan="4">
                                    Fotograf bulunamadı.
                                    </td>
                                </tr>
                            {/if}
                        {/await}
                      </tbody>
                    </table>
              </div>
            </div>
        </div>
        </div>
        
</div></div>