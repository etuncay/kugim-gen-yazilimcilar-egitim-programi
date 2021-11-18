<script>
    import { Navigate } from 'svelte-router-spa';
  
   async function Sil(id){
      let onay = confirm("Silmek istediğinize eminmisiniz");
      if(onay){
       let result = await fetch("https://localhost:44364/api/Icerik/Sil?id="+id,
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
              location.href = '/icerik/liste';
          }
      }
    }   
  
    let items =  fetch("https://localhost:44364/api/Icerik/Listele",
        {
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
            },
            method: "GEt"
        })
        .then(function(res){ 
          return res.json();
         });
        
    
  
  </script>
  <div class="container-xl">
      <!-- Page title -->
      <div class="page-header d-print-none">
        <div class="row align-items-center">
          <div class="col">
            <h2 class="page-title">
                İcerik Liste
            </h2>
          </div>
        </div>
      </div>
    </div>
    <div class="page-body">
      <div class="container-xl">
          
  <div class="col-12">
      <div class="card">
        <div class="card-header">
          <ul class="nav nav-tabs card-header-tabs">
            <li class="nav-item">
                İçerikler
            </li>
            
            <li class="nav-item ms-auto">
              <Navigate to="icerik/ekle">Yeni Ekle</Navigate>
             
            </li>
          </ul>
        </div>
        <div class="table-responsive">
          <table
  class="table table-vcenter card-table">
            <thead>
              <tr>
                <th>#</th>
                <th>Resim</th>
                <th>Başlık</th>
                <th>İçerik Tipi</th>
                <th>Kategori</th>
                <th class="w-1"></th>
                <th class="w-1"></th>
              </tr>
            </thead>
            <tbody>
              {#await items}
                <tr>
                  <td colspan="3">
                    Veriler güncelleniyor.
                  </td>
                </tr>
              {:then value}
                {#each value.data as item,  i}
                  <tr>
                    <td>{i+1}</td>
                    <td><img src={item.resimUrl} ></td>
                    <td>{item.baslik}</td>
                    <td>{item.icerikTipi.label}</td>
                    <td>{item.kategori.label}</td>
                    <td>  
                    <Navigate to="/icerik/duzenle/{item.id}">Düzenle</Navigate>
  
                    </td>
                    <td>
                    <a href="#" on:click={() => Sil(item.id)}>Sil</a>
  
                    </td>
                  </tr>
                {/each}
                
              {/await}
             
             
            </tbody>
          </table>
        </div>
      </div>
    </div>
      </div>
    </div>
  