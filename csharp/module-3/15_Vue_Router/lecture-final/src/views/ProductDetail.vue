<template>
  <div id="app" class="main">
    <h1>{{ product.name }}</h1>
    <p class="description">{{ product.description }}</p>
    <div class="actions">
      <router-link v-bind:to="{ name: 'products'}">Back to Products</router-link>
      &nbsp;|
      <router-link v-bind:to="{ name: 'add-review', params: { id: product.id}}">
          Add Review 
          </router-link>
    </div>
    <div class="well-display">
      <average-summary />
      <star-summary rating="1" />
      <star-summary rating="2" />
      <star-summary rating="3" />
      <star-summary rating="4" />
      <star-summary rating="5" />
    </div>
    <review-list />
  </div>
</template>

<script>
import AverageSummary from '../components/AverageSummary.vue';
import StarSummary from '../components/StarSummary.vue';
import ReviewList from '../components/ReviewList.vue';

export default {
    name: 'product-detail',
    components: {
        AverageSummary, StarSummary, ReviewList
    },
    computed: {
        product() {
            return this.$store.getters.product;
            //use the getter for product in the store so that it always
            //gives me the product with the active product ID 
        }
    },

    //I want to set the 'active product' in the store to the id in my route
    created() {
        //get the product id from the route
        const activeProductId = this.$route.params.id;
        //commit a mutation to change the value in the store 
        this.$store.commit('SET_ACTIVE_PRODUCT', activeProductId);
    }
    //created() is a lifecycle hook that runs when the view is being made
    //so that this code runs before the view gets displayed in the DOM
}

</script>

<style>

</style>