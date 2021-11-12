<script>
    import { Route } from 'svelte-router-spa'
    export let currentRoute
    const params = {}

	import Header from '../header.svelte'
	import Navbar from '../navbar.svelte'
	import Footer from '../footer.svelte'
    
</script>
<div class="wrapper">

	<!--header-->
	<Header />

	<!--Navbar-->
	<Navbar/>	
	
	<div class="page-wrapper">
        
        <Route {currentRoute}  {params} />
	  
	  <!--footer-->
	  <Footer/>
	</div>
  </div>
  <!-- Libs JS -->
  <!-- Tabler Core -->