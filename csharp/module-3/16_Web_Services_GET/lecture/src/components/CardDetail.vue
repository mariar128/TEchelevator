<template>
  <div>
    <h1>{{card.title}}</h1>
    <h2>{{card.status}}</h2>
    <p>{{card.description}}</p>
    <comments-list v-bind:comments="card.comments"/>
  </div>
</template>

<script>
import BoardService from '../services/BoardService.js';
import CommentsList from '../components/CommentsList.vue'
export default {
  name: "card-detail",
  components: {CommentsList},
  data() {
    return {
      card: {}
    }
  },
  created() {
    BoardService.getCard(this.$route.params.boardID, this.$route.params.cardID)
    .then((response) => {
      this.card = response;
    });
  
  
  
}
  //get data from API and put the call in the created hook. bc you wanna fire off ur request for data asap, before the dom
};
</script>
