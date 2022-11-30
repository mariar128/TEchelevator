<template>
  <div class="card">
    <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
    <!-- Please leave <img> commented out until directed to remove open and close comment tags in the README.
    -->
    <div>
        <h2 class="book-title">{{ book.title }}</h2>
        <p class="book-author">{{ book.author }}</p>
        <p class="book-description">{{ book.description }}</p>
        <p>{{ book.isbn }}</p>
        <p>{{ book.published }}</p>
    </div>
    <div class="card-footer">
        <button v-on:click="mark-read" class="button">{{ book.read ? 'read' : 'unread'}}</button>
        <button v-on:click="mark-read" class="button mark-read">Mark as Read</button>
        <button v-on:click="mark-unread" class="button mark-unread">Mark as Unread</button>
    </div>
  </div>
</template>
<script>
export default {
  name: 'book-card',
  props: {
      book: {
          type: Object,
          required: true
      }
  },
}
</script>
<style>
.card {
    border: 2px solid black;
    border-radius: 10px;
    width: 250px;
    height: 550px;
    margin: 20px;
}
.card.read {
    background-color: lightgray;
}
.card .book-title {
    font-size: 1.5rem;
}
.card .book-author {
    font-size: 1rem;
}
</style>