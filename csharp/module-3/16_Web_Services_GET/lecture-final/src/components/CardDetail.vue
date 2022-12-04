<template>
  <div>
    <h1>{{card.title}}</h1>
    <h2>{{card.status}} -- {{card.date}}</h2>
    <p>{{card.description}}</p>
    <comments-list v-bind:comments="card.comments"/>
  </div>
</template>

<script>
import boardService from '../services/BoardService.js';
import CommentsList from '../components/CommentsList.vue';

export default {
  name: "card-detail",
  components: { CommentsList },
  data() {
    return {
      card: {}
    }
  },
  //get data from the API and we'll put the call in the created hook
  created() {
    boardService.getCard(this.$route.params.boardID, this.$route.params.cardID).then((response) => {
        this.card = response;
    })
  }
};
</script>
