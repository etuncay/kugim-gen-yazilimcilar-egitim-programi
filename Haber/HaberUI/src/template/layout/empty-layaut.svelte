<script>
    import { Route } from 'svelte-router-spa'
    export let currentRoute
    const params = {}

</script>

<div class="page page-center">
    <div class="container-tight py-4">
        <Route {currentRoute}  {params} />
    </div>
</div>
   