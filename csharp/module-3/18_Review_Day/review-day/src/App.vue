<template>
  <div id="app">
    <to-dos v-bind:todos="$store.state.todos"/>
    <to-do-form v-bind:todo='$store.state.todos[0]'/>
  </div>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import ToDoForm from './components/ToDoForm.vue'
import ToDos from './components/ToDos.vue'

export default {
  name: 'App',
  components: {
    ToDoForm, ToDos
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
