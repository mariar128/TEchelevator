<template>
  <div>
      <h1>Add Review</h1>
      <add-review/>
  </div>
</template>

<script>
import AddReview from '../components/AddReview.vue'

export default {
    name: 'add-product-review', //don't name the same as the thing you're importing
    components: { AddReview }
}
</script>

<style>

</style>
