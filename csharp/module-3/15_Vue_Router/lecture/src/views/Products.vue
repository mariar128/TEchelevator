<template>
<div>
    <h1>Products</h1>
<products-list>
</template>

<script>
//import the components you want to use in the view
import ProductsList from '../components/ProductsList.vue'
export default {
    //add the components used to the components object
    components: {
        ProductsList
    }
}
</script>

<style>

</style>