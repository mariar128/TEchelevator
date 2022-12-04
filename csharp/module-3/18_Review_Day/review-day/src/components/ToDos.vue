<template>
  <div>
      <div v-for="todo in todos" v-bind:key="todo">
          <h3>{{todo.title}}</h3>
      </div>
  </div>
</template>

<script>
export default {
name: "todo-list",
  props: ['todos'],
}
</script>

<style>

</style>