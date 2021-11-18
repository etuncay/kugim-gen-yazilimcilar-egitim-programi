<script>
    import { Route } from 'svelte-router-spa'
    export let currentRoute   
    let id= currentRoute.namedParams.id;
    let ad ='';
    let aciklama ='';

    (async () => {

        const rawResponse = await fetch('https://localhost:44364/api/Kategori/Getir?id='+id, {
            method: 'GET',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            }
        });
        const content = await rawResponse.json();

            if(content.type=='Success'){
                ad = content.data.ad;
                aciklama = content.data.aciklama;
            }else{
                alert(content.message)    
            }

        })();
   

    async function Duzenle(){
        let postData ={
            ad: ad,
            aciklama: aciklama,
            };

        let result = await fetch("https://localhost:44364/api/Kategori/Guncelle?id="+id,
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
            location.href = '/kategori/liste';
        }
    }

</script>
<div class="container-xl">
    <!-- Page title -->
    <div class="page-header d-print-none">
      <div class="row align-items-center">
        <div class="col">
          <h2 class="page-title">
            Kategori Düzenle
          </h2>
        </div>
      </div>
    </div>
  </div>
  <div class="page-body">
    <div class="container-xl">
        <div class="card">
            <div class="card-header">
              <h3 class="card-title">Horizontal form</h3>
            </div>
            <div class="card-body">
              <form on:submit|preventDefault={Duzenle} >
                <div class="form-group mb-3 row">
                  <label class="form-label col-3 col-form-label">Ad</label>
                  <div class="col">
                    <input type="text" class="form-control" bind:value={ad} placeholder="Kategori için uygun bir ad giriniz">
                    <small class="form-hint">We'll never share your email with anyone else.</small>
                  </div>
                </div>
                <div class="form-group mb-3 row">
                    <label class="form-label col-3 col-form-label">Açıklama</label>
                    <div class="col">
                        <textarea class="form-control" bind:value= {aciklama} ></textarea>
                      <small class="form-hint">We'll never share your email with anyone else.</small>
                    </div>
                  </div>
                <div class="form-footer">
                  <button type="submit" class="btn btn-primary">Gönder</button>
                </div>
              </form>
            </div>
          </div>
    </div>
</div>
